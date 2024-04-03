namespace BlazorApplicationInsights.Models.Context;
using System.Text.Json.Serialization;

/// <summary>
/// Automatic Session Manager
/// Source: https://github.com/microsoft/ApplicationInsights-JS/blob/main/shared/AppInsightsCommon/src/Interfaces/Context/ISessionManager.ts
/// </summary>
public class SessionManager {
	/// <summary>
	/// The automatic Session which has been initialized from the automatic SDK cookies and storage.
	/// </summary>
	[JsonPropertyName("automaticSession")]
	public Session AutomaticSession { get; set; } = default!;

	//todo
	//public async Task Update()
	//{
	//    throw new NotImplementedException();
	//}

	//todo
	//public async Task Backup()
	//{
	//    throw new NotImplementedException();
	//}
}
