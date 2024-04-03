namespace BlazorApplicationInsights.Interfaces;

using BlazorApplicationInsights.Models;
using System.ComponentModel;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Browsable(false)]
public interface IPropertiesPlugin {
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	Task<TelemetryContext> Context();
}
