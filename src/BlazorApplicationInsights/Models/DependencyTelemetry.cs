namespace BlazorApplicationInsights.Models;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Dependency Telemetry
/// Source: https://github.com/microsoft/ApplicationInsights-JS/blob/main/shared/AppInsightsCommon/src/Interfaces/IDependencyTelemetry.ts
/// </summary>
public class DependencyTelemetry : PartC {

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = "";

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("duration")]
	public double? Duration { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("success")]
	public bool? Success { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("startTime")]
	[JsonConverter(typeof(DateTimeJsonConverter))]
	public DateTime? StartTime { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("responseCode")]
	public int ResponseCode { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("correlationContext")]
	public string? CorrelationContext { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("data")]
	public string? Data { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("target")]
	public string? Target { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("iKey")]
	public string? IKey { get; set; }
}

/// <summary>
/// 
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Browsable(false)]
public class DateTimeJsonConverter : JsonConverter<DateTime> {

	/// <summary>
	/// 
	/// </summary>
	/// <param name="reader"></param>
	/// <param name="typeToConvert"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		throw new NotImplementedException();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="writer"></param>
	/// <param name="value"></param>
	/// <param name="options"></param>
	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
		writer.WriteNumberValue((decimal)(new DateTimeOffset(value)).ToUnixTimeMilliseconds());
	}

}