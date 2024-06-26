﻿namespace BlazorApplicationInsights;

using BlazorApplicationInsights.Interfaces;
using BlazorApplicationInsights.Models;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
[PublicAPI]
public static class IServiceCollectionExtensions {

	// Nasty, but needed for unit testing.
	// ReSharper disable once MemberCanBePrivate.Global
	internal static bool PretendBrowserPlatform { get; set; }
	private static bool IsBrowserPlatform => PretendBrowserPlatform || OperatingSystem.IsBrowser();

	/// <summary>
	/// Adds the BlazorApplicationInsights services.
	/// </summary>
	/// <param name="services"></param>
	/// <param name="builder">Callback for configuring the service.</param>
	/// <param name="onAppInsightsInit">Callback which allows calling Application Insights commands on startup.  Note, requires component to be interactive!</param>
	/// <param name="addWasmLogger">Adds the ILoggerProvider which ships all logs to Application Insights. This is disabled on Blazor Server.</param>
	/// <param name="loggingOptions">Callback for configuring the logging options. Blazor WASM only.</param>
	public static IServiceCollection AddBlazorApplicationInsights(this IServiceCollection services, Action<Config>? builder = null, Func<IApplicationInsights, Task>? onAppInsightsInit = null, bool addWasmLogger = true, Action<ApplicationInsightsLoggerOptions>? loggingOptions = null) {
		var initConfig = new ApplicationInsightsInitConfig();

		if (builder != null) {
			var config = new Config();
			builder(config);
			initConfig.Config = config;
		}

		if (onAppInsightsInit != null) {
			initConfig.OnAppInsightsInit = onAppInsightsInit;
		}

		services.TryAddSingleton(initConfig);

		if (addWasmLogger && IsBrowserPlatform) {
			services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ApplicationInsightsLoggerProvider>(x => CreateLoggerProvider(x, loggingOptions)));
		}

		services.TryAddSingleton<IApplicationInsights, ApplicationInsights>();

		return services;
	}

	private static ApplicationInsightsLoggerProvider CreateLoggerProvider(IServiceProvider services, Action<ApplicationInsightsLoggerOptions>? configure) {
		configure ??= delegate { };

		var options = new ApplicationInsightsLoggerOptions();
		configure(options);

		// Sure, this is a little insane, but I had already gone with IOptions
		// before ripping out Microsoft.Extensions.Logging.Configuration.
		// Rather than redoing the plumbing, let's just keep it and
		// if we want to add Logging.Configuration later it should be easy.
		var optionsMonitor = new DummyOptionsMonitor(options);
		var appInsights = services.GetRequiredService<IApplicationInsights>();

		return new ApplicationInsightsLoggerProvider(appInsights, optionsMonitor);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <param name="currentValue"></param>
	private class DummyOptionsMonitor(ApplicationInsightsLoggerOptions currentValue) : IOptionsMonitor<ApplicationInsightsLoggerOptions> {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ApplicationInsightsLoggerOptions Get(string? name) {
			if (string.IsNullOrWhiteSpace(name)) {
				return default!;
			}
			return this.CurrentValue;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="listener"></param>
		/// <returns></returns>
		public IDisposable OnChange(Action<ApplicationInsightsLoggerOptions, string> listener)
			=> NoOpDisposable.Instance;

		/// <summary>
		/// 
		/// </summary>
		public ApplicationInsightsLoggerOptions CurrentValue { get; set; } = currentValue;

	}

}