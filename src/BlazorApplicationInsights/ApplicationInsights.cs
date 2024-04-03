namespace BlazorApplicationInsights;

using BlazorApplicationInsights.Interfaces;
using BlazorApplicationInsights.Models;
using Microsoft.JSInterop;

/// <inheritdoc />
public class ApplicationInsights : IApplicationInsights {

	private IJSRuntime _jsRuntime = default!;

	/// <inheritdoc />
	public void InitJSRuntime(IJSRuntime jSRuntime) {
		this._jsRuntime = jSRuntime;
	}

	/// <inheritdoc />
	public async Task TrackPageView(PageViewTelemetry? pageView = null)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackPageView", pageView);

	/// <inheritdoc />
	public async Task TrackEvent(EventTelemetry @event)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackEvent", @event);

	/// <inheritdoc />
	public async Task TrackTrace(TraceTelemetry trace)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackTrace", trace);

	/// <inheritdoc />
	public async Task TrackException(ExceptionTelemetry exception)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackException", exception);

	/// <inheritdoc />
	public async Task StartTrackPage(string? name = null)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.startTrackPage", name!);

	/// <inheritdoc />
	public async Task StopTrackPage(string? name = null, string? url = null, Dictionary<string, object?>? customProperties = null, Dictionary<string, decimal>? measurements = null)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.stopTrackPage", name, url, customProperties, measurements);

	/// <inheritdoc />
	public async Task TrackMetric(MetricTelemetry metric)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackMetric", metric);

	/// <inheritdoc />
	public async Task TrackDependencyData(DependencyTelemetry dependency)
		=> await this._jsRuntime.InvokeVoidAsync("blazorApplicationInsights.trackDependencyData", dependency);

	/// <inheritdoc />
	public async Task Flush()
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.flush", false);

	/// <inheritdoc />
	public async Task ClearAuthenticatedUserContext()
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.clearAuthenticatedUserContext");

	/// <inheritdoc />
	public async Task SetAuthenticatedUserContext(string authenticatedUserId, string? accountId = null, bool? storeInCookie = null)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.setAuthenticatedUserContext", authenticatedUserId, accountId, storeInCookie);

	/// <inheritdoc />
	public async Task AddTelemetryInitializer(TelemetryItem telemetryItem)
		=> await this._jsRuntime.InvokeVoidAsync("blazorApplicationInsights.addTelemetryInitializer", telemetryItem);

	/// <inheritdoc />
	public async Task TrackPageViewPerformance(PageViewPerformanceTelemetry pageViewPerformance)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.trackPageViewPerformance", pageViewPerformance);

	/// <inheritdoc />
	public async Task StartTrackEvent(string name)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.startTrackEvent", name);

	/// <inheritdoc />
	public async Task StopTrackEvent(string name, Dictionary<string, object?>? properties = null, Dictionary<string, decimal>? measurements = null)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.stopTrackEvent", name, properties, measurements);

	/// <inheritdoc />
	public async Task UpdateCfg(Config newConfig, bool mergeExisting = true)
		=> await this._jsRuntime.InvokeVoidAsync("appInsights.updateCfg", newConfig, mergeExisting);

	/// <inheritdoc />
	public async Task<TelemetryContext> Context()
		=> await this._jsRuntime.InvokeAsync<TelemetryContext>("blazorApplicationInsights.getContext");

	/// <inheritdoc />
	public CookieMgr GetCookieMgr() {
		return new CookieMgr(this._jsRuntime);
	}
}
