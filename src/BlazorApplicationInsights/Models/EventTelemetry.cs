namespace BlazorApplicationInsights.Models;
using System.Text.Json.Serialization;

/// <summary>
/// Source: https://github.com/microsoft/ApplicationInsights-JS/blob/main/shared/AppInsightsCommon/src/Interfaces/IEventTelemetry.ts
/// </summary>
public class EventTelemetry : PartC {

	/// <summary>
	/// An event name string.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/// <summary>
	/// Custom defined iKey.
	/// </summary>
	[JsonPropertyName("iKey")]
#pragma warning disable IDE1006 // Naming Styles
	public string? iKey { get; set; } = "";
#pragma warning restore IDE1006 // Naming Styles

}