﻿namespace BlazorApplicationInsights.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Configuration settings for how telemetry is sent
/// Source: https://github.com/microsoft/ApplicationInsights-JS/blob/main/shared/AppInsightsCommon/src/Interfaces/IConfig.ts
/// </summary>
public class Config : Configuration {
	/// <summary>
	/// The JSON format (normal vs line delimited). True means line delimited JSON.
	/// </summary>
	[JsonPropertyName("emitLineDelimitedJson")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EmitLineDelimitedJson { get; set; }

	/// <summary>
	/// An optional account id, if your app groups users into accounts. No spaces, commas, semicolons, equals, or vertical bars.
	/// </summary>
	[JsonPropertyName("accountId")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? AccountId { get; set; }

	/// <summary>
	/// A session is logged if the user is inactive for this amount of time in milliseconds. Default 30 mins.
	/// Default 30*60*1000
	/// </summary>
	[JsonPropertyName("sessionRenewalMs")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? SessionRenewalMs { get; set; }

	/// <summary>
	/// A session is logged if it has continued for this amount of time in milliseconds. Default 24h.
	/// Default 24*60*60*1000
	/// </summary>
	[JsonPropertyName("sessionExpirationMs")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? SessionExpirationMs { get; set; }

	/// <summary>
	/// Max size of telemetry batch. If batch exceeds limit, it is sent and a new batch is started.
	/// Default 100000
	/// </summary>
	[JsonPropertyName("maxBatchSizeInBytes")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? MaxBatchSizeInBytes { get; set; }

	/// <summary>
	/// How long to batch telemetry for before sending (milliseconds).
	/// Default 15s
	/// </summary>
	[JsonPropertyName("maxBatchInterval")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? MaxBatchInterval { get; set; }

	/// <summary>
	/// If true, exceptions are not autocollected. Default is false.
	/// </summary>
	[JsonPropertyName("disableExceptionTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableExceptionTracking { get; set; }

	/// <summary>
	/// If true, telemetry is not collected or sent. Default is false.
	/// </summary>
	[JsonPropertyName("disableTelemetry")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableTelemetry { get; set; }

	/// <summary>
	/// Percentage of events that will be sent. Default is 100, meaning all events are sent.
	/// </summary>
	[JsonPropertyName("samplingPercentage")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? SamplingPercentage { get; set; }

	/// <summary>
	/// If true, on a pageview, the previous instrumented page's view time is tracked and sent as telemetry and a new timer is started for the current pageview.
	/// </summary>
	[JsonPropertyName("autoTrackPageVisitTime")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? AutoTrackPageVisitTime { get; set; }

	/// <summary>
	/// Automatically track route changes in Blazor. If true, each route change will send a new Pageview to Application Insights.
	/// </summary>
	[JsonPropertyName("enableAutoRouteTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableAutoRouteTracking { get; set; } = true;

	/// <summary>
	/// If true, Ajax calls are not autocollected. Default is false.
	/// </summary>
	[JsonPropertyName("disableAjaxTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableAjaxTracking { get; set; }

	/// <summary>
	/// If true, Fetch requests are not autocollected. Default is false (Since 2.8.0, previously true).
	/// </summary>
	[JsonPropertyName("disableFetchTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableFetchTracking { get; set; }

	/// <summary>
	/// Provide a way to exclude specific route from automatic tracking for XMLHttpRequest or Fetch request. For an ajax / fetch request that the request url matches with the regex patterns, auto tracking is turned off.
	/// </summary>
	[JsonPropertyName("excludeRequestFromAutoTrackingPatterns")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public List<string>? ExcludeRequestFromAutoTrackingPatterns { get; set; }

	//todo
	//[JsonPropertyName("addRequestContext")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public Func<IRequestContext, ICustomProperties>? AddRequestContext { get; set; }

	/// <summary>
	/// If true, default behavior of trackPageView is changed to record end of page view duration interval when trackPageView is called. If false and no custom duration is provided to trackPageView, the page view performance is calculated using the navigation timing API. Default is false.
	/// </summary>
	[JsonPropertyName("overridePageViewDuration")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? OverridePageViewDuration { get; set; }

	/// <summary>
	/// Controls how many ajax calls will be monitored per page view. Set to -1 to monitor all (unlimited) ajax calls on the page.
	/// Default 500
	/// </summary>
	[JsonPropertyName("maxAjaxCallsPerView")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? MaxAjaxCallsPerView { get; set; }

	/// <summary>
	/// If false, internal telemetry sender buffers will be checked at startup for items not yet sent. Default is true.
	/// </summary>
	[JsonPropertyName("disableDataLossAnalysis")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableDataLossAnalysis { get; set; }

	/// <summary>
	/// If false, the SDK will add two headers ('Request-Id' and 'Request-Context') to all dependency requests to correlate them with corresponding requests on the server side. Default is false.
	/// </summary>
	[JsonPropertyName("disableCorrelationHeaders")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableCorrelationHeaders { get; set; }

	/// <summary>
	/// Sets the distributed tracing mode. If AI_AND_W3C mode or W3C mode is set, W3C trace context headers (traceparent/tracestate) will be generated and included in all outgoing requests.
	/// Default AI_AND_W3C
	/// </summary>
	[JsonPropertyName("distributedTracingMode")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? DistributedTracingMode { get; set; }

	/// <summary>
	/// Disable correlation headers for specific domain.
	/// </summary>
	[JsonPropertyName("correlationHeaderExcludedDomains")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public List<string>? CorrelationHeaderExcludedDomains { get; set; }

	/// <summary>
	/// If true, flush method will not be called when onBeforeUnload, onUnload, onPageHide, or onVisibilityChange (hidden state) event(s) trigger.
	/// Default false
	/// </summary>
	[JsonPropertyName("disableFlushOnBeforeUnload")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableFlushOnBeforeUnload { get; set; }

	/// <summary>
	/// If true, flush method will not be called when onPageHide or onVisibilityChange (hidden state) event(s) trigger.
	/// </summary>
	[JsonPropertyName("disableFlushOnUnload")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableFlushOnUnload { get; set; }

	/// <summary>
	/// If true, the buffer with all unsent telemetry is stored in session storage. The buffer is restored on page load. Default is true.
	/// </summary>
	[JsonPropertyName("enableSessionStorageBuffer")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableSessionStorageBuffer { get; set; }

	//todo
	//[JsonPropertyName("bufferOverride")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public IStorageBuffer? BufferOverride { get; set; }

	/// <summary>
	/// If false, retry on 206 (partial success), 408 (timeout), 429 (too many requests), 500 (internal server error), 503 (service unavailable), and 0 (offline, only if detected).
	/// Default false
	/// </summary>
	[JsonPropertyName("isRetryDisabled")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? IsRetryDisabled { get; set; }

	/// <summary>
	/// If true, the SDK will not store or read any data from local and session storage. Default is false.
	/// </summary>
	[JsonPropertyName("isStorageUseDisabled")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? IsStorageUseDisabled { get; set; }

	/// <summary>
	/// If false, the SDK will send all telemetry using the Beacon API.
	/// Default true
	/// </summary>
	[JsonPropertyName("isBeaconApiDisabled")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? IsBeaconApiDisabled { get; set; }

	/// <summary>
	/// Don't use XMLHttpRequest or XDomainRequest (for IE &lt; 9) by default; instead attempt to use fetch() or sendBeacon.
	/// If no other transport is available it will still use XMLHttpRequest
	/// </summary>
	[JsonPropertyName("disableXhr")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableXhr { get; set; }

	/// <summary>
	/// If fetch keepalive is supported, do not use it for sending events during unload, it may still fallback to fetch() without keepalive.
	/// </summary>
	[JsonPropertyName("onunloadDisableFetch")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? OnUnloadDisableFetch { get; set; }

	/// <summary>
	/// Sets the SDK extension name. Only alphabetic characters are allowed. The extension name is added as a prefix to the 'ai.internal.sdkVersion' tag (e.g. 'ext_javascript:2.0.0'). Default is null.
	/// </summary>
	[JsonPropertyName("sdkExtension")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? SdkExtension { get; set; }

	/// <summary>
	/// If true, the SDK will track all Browser Link requests.
	/// Default is false
	/// </summary>
	[JsonPropertyName("isBrowserLinkTrackingEnabled")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? IsBrowserLinkTrackingEnabled { get; set; }

	/// <summary>
	/// AppId is used for the correlation between AJAX dependencies happening on the client-side with the server-side requests. When Beacon API is enabled, it cannot be used automatically, but can be set manually in the configuration. Default is null.
	/// </summary>
	[JsonPropertyName("appId")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? AppId { get; set; }

	/// <summary>
	/// If true, the SDK will add two headers ('Request-Id' and 'Request-Context') to all CORS requests to correlate outgoing AJAX dependencies with corresponding requests on the server side. Default is false.
	/// </summary>
	[JsonPropertyName("enableCorsCorrelation")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableCorsCorrelation { get; set; }

	/// <summary>
	/// An optional value that will be used as name postfix for localStorage and session cookie name.
	/// </summary>
	[JsonPropertyName("namePrefix")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? NamePrefix { get; set; }

	/// <summary>
	/// An optional value that will be used as name postfix for session cookie name. If undefined, namePrefix is used as name postfix for session cookie name.
	/// </summary>
	[JsonPropertyName("sessionCookiePostfix")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? SessionCookiePostfix { get; set; }

	/// <summary>
	/// An optional value that will be used as name postfix for user cookie name. If undefined, no postfix is added on user cookie name.
	/// </summary>
	[JsonPropertyName("userCookiePostfix")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? UserCookiePostfix { get; set; }

	/// <summary>
	/// An optional value that will track Request Header through trackDependency function.
	/// Default false
	/// </summary>
	[JsonPropertyName("enableRequestHeaderTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableRequestHeaderTracking { get; set; }

	/// <summary>
	/// An optional value that will track Response Header through trackDependency function.
	/// Default false
	/// </summary>
	[JsonPropertyName("enableResponseHeaderTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableResponseHeaderTracking { get; set; }

	/// <summary>
	/// An optional value that will track Response Error data through trackDependency function.
	/// Default false
	/// </summary>
	[JsonPropertyName("enableAjaxErrorStatusText")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableAjaxErrorStatusText { get; set; }

	/// <summary>
	/// Flag to enable looking up and including additional browser window.performance timings in the reported ajax (XHR and fetch) reported metrics.
	/// Default false
	/// </summary>
	[JsonPropertyName("enableAjaxPerfTracking")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? EnableAjaxPerfTracking { get; set; }

	/// <summary>
	/// The maximum number of times to look for the window.performance timings (if available), this is required as not all browsers populate the window.performance before reporting the end of the XHR request and for fetch requests this is added after its complete.
	/// Default 3
	/// </summary>
	[JsonPropertyName("maxAjaxPerfLookupAttempts")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? MaxAjaxPerfLookupAttempts { get; set; }

	/// <summary>
	/// The maximum number of times to look for the window.performance timings (if available), this
	/// is required as not all browsers populate the window.performance before reporting the
	/// end of the XHR request and for fetch requests this is added after its complete
	/// Defaults to 3
	/// </summary>
	[JsonPropertyName("ajaxPerfLookupDelay")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? AjaxPerfLookupDelay { get; set; }

	/// <summary>
	/// When tab is closed, the SDK will send all remaining telemetry using the [Beacon API](https://www.w3.org/TR/beacon)
	/// Default false
	/// </summary>
	[JsonPropertyName("onunloadDisableBeacon")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? OnunloadDisableBeacon { get; set; }

	/// <summary>
	/// Enable correlation headers for specific domains
	/// </summary>
	[JsonPropertyName("correlationHeaderDomains")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public List<string>? CorrelationHeaderDomains { get; set; }

	//[JsonPropertyName("correlationHeaderExcludePatterns")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public List<string>? CorrelationHeaderExcludePatterns { get; set; }

	//[JsonPropertyName("customHeaders")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public List<CustomHeader>? CustomHeaders { get; set; }

	//[JsonPropertyName("convertUndefined")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public object? ConvertUndefined { get; set; }

	/// <summary>
	/// [Optional] The number of events that can be kept in memory before the SDK starts to drop events. By default, this is 10,000.
	/// </summary>
	[JsonPropertyName("eventsLimitInMem")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public int? EventsLimitInMem { get; set; }

	/// <summary>
	/// [Optional] Disable iKey deprecation error message.
	/// </summary>
	[JsonPropertyName("disableIkeyDeprecationMessage")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? DisableIkeyDeprecationMessage { get; set; }

	/// <summary>
	/// [Optional] Flag to indicate whether the internal looking endpoints should be automatically
	/// added to the `excludeRequestFromAutoTrackingPatterns` collection. (defaults to true).
	/// This flag exists as the provided regex is generic and may unexpectedly match a domain that
	/// should not be excluded.        /// </summary>
	[JsonPropertyName("addIntEndpoints")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? AddIntEndpoints { get; set; }

	//[JsonPropertyName("throttleMgrCfg")]
	//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	//public IThrottleMgrConfig? ThrottleMgrCfg { get; set; }
}
