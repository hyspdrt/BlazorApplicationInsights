﻿namespace BlazorApplicationInsights.Models.Context;
using System.Text.Json.Serialization;

/// <summary>
/// Source: https://github.com/microsoft/ApplicationInsights-JS/blob/main/shared/AppInsightsCommon/src/Interfaces/Context/ILocation.ts
/// </summary>
public class Location {
	/// <summary>
	/// Client IP address for reverse lookup.
	/// </summary>
	[JsonPropertyName("ip")]
	public string Ip { get; set; } = "";
}
