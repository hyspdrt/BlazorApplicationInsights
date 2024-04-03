// ReSharper disable once CheckNamespace
namespace BlazorApplicationInsights;
using BlazorApplicationInsights.Interfaces;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

/// <summary>LoggerProvider implementation for logging to Application Insights in Blazor Client-Side (WASM) applications</summary>
[PublicAPI]
public class ApplicationInsightsLoggerProvider : ILoggerProvider, ISupportExternalScope {

	private readonly IApplicationInsights _applicationInsights;
	private readonly ConcurrentDictionary<string, ApplicationInsightsLogger> _loggers = new ConcurrentDictionary<string, ApplicationInsightsLogger>();
	private readonly IDisposable? _optionsReloadToken;
	private Action<Dictionary<string, object?>> _enrichmentCallback = delegate { };
	private IExternalScopeProvider? _scopeProvider;
	private ApplicationInsightsLoggerOptions _options = new ApplicationInsightsLoggerOptions();
	private bool _isDisposed;

	/// <summary>Initializes a new instance of the <see cref="ApplicationInsightsLoggerProvider"/> class</summary>
	/// <param name="applicationInsights">Instance to use for transmitting logging messages</param>
	public ApplicationInsightsLoggerProvider(IApplicationInsights applicationInsights) {
		this._applicationInsights = applicationInsights;
		this._optionsReloadToken = NoOpDisposable.Instance;
	}

	/// <summary>Initializes a new instance of the <see cref="ApplicationInsightsLoggerProvider"/> class</summary>
	/// <param name="applicationInsights">Instance to use for transmitting logging messages</param>
	/// <param name="options">Logger options</param>
	[ActivatorUtilitiesConstructor]
	public ApplicationInsightsLoggerProvider(IApplicationInsights applicationInsights, IOptionsMonitor<ApplicationInsightsLoggerOptions> options) {
		this._applicationInsights = applicationInsights;
		this._optionsReloadToken = options.OnChange(this.ReloadOptions);
		this.ReloadOptions(options.CurrentValue);
	}

	/// <inheritdoc />
	public ILogger CreateLogger(string categoryName) =>
		this._loggers.GetOrAdd(categoryName, this.CreateLoggerInstance);

	/// <inheritdoc />
	public void SetScopeProvider(IExternalScopeProvider scopeProvider) {
		this._scopeProvider = scopeProvider;

		foreach (var logger in this._loggers.Values) {
			logger.ScopeProvider = scopeProvider;
		}
	}

	/// <inheritdoc />
	public void Dispose() {
		GC.SuppressFinalize(this);
		if (this._isDisposed) {
			return;
		}

		this._isDisposed = true;
		this._optionsReloadToken?.Dispose();
	}

	private ApplicationInsightsLogger CreateLoggerInstance(string categoryName) {
		return new ApplicationInsightsLogger(categoryName, this._applicationInsights) {
			ScopeProvider = this.GetScopeProvider(),
			IncludeScopes = this._options.IncludeScopes,
			IncludeCategoryName = this._options.IncludeCategoryName,

#pragma warning disable 618
			EnrichmentCallback = this._enrichmentCallback
#pragma warning restore 618
		};
	}

	private IExternalScopeProvider GetScopeProvider() {
		this._scopeProvider ??= new LoggerExternalScopeProvider();
		return this._scopeProvider;
	}

	private void ReloadOptions(ApplicationInsightsLoggerOptions options) {
		this._options = options;

#pragma warning disable 618
		this._enrichmentCallback = options.EnrichCallback ?? delegate { };
#pragma warning restore 618

		var scopeProvider = this.GetScopeProvider();
		foreach (var logger in this._loggers.Values) {
			logger.ScopeProvider = scopeProvider;
			logger.IncludeCategoryName = options.IncludeCategoryName;
			logger.IncludeScopes = options.IncludeScopes;

#pragma warning disable 618
			logger.EnrichmentCallback = this._enrichmentCallback;
#pragma warning restore 618
		}
	}
}
