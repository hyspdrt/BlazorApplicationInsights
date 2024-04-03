namespace BlazorApplicationInsights
{
	using BlazorApplicationInsights.Interfaces;
	using BlazorApplicationInsights.Models;
	using System;
	using System.Threading.Tasks;

	internal class ApplicationInsightsInitConfig
    {
        public Config? Config { get; set; }

        public Func<IApplicationInsights, Task>? OnAppInsightsInit { get; set; }
    }
}
