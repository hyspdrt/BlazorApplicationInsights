namespace BlazorApplicationInsights.Models;
using System.Text.Json.Serialization;

/// <summary>
/// 
/// </summary>
public class Error {

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = "";

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("stack")]
	public string? Stack { get; set; }

}