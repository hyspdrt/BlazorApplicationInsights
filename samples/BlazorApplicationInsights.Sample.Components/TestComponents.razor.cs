namespace BlazorApplicationInsights.Sample.Components;

using BlazorApplicationInsights.Interfaces;
using BlazorApplicationInsights.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

public partial class TestComponents {

	[Inject]
	private ILogger<TestComponents> Logger { get; set; } = default!;

	[Inject]
	private IApplicationInsights AppInsights { get; set; } = default!;

	[Inject] HttpClient HttpClient { get; set; } = default!;

	private string UserId = string.Empty;
	private string SessionId = string.Empty;

	private bool? CookiesEnabled;

	private async Task TrackEvent() {
		await this.AppInsights.TrackEvent(new EventTelemetry() { Name = "My Event", Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } } });
		await this.AppInsights.Flush();
	}

	private async Task TrackTrace() {
		await this.AppInsights.TrackTrace(new TraceTelemetry() { Message = "myMessage" });
		await this.AppInsights.Flush();
		await this.AppInsights.TrackTrace(new TraceTelemetry() { Message = "myMessage1", SeverityLevel = SeverityLevel.Critical });
		await this.AppInsights.Flush();
		await this.AppInsights.TrackTrace(new TraceTelemetry() { Message = "myMessage2", SeverityLevel = SeverityLevel.Critical, Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } } });
		await this.AppInsights.Flush();
	}

	private async Task TrackException() {
		await this.AppInsights.TrackException(new ExceptionTelemetry() { Exception = new() { Message = "my message", Name = "my error" }, SeverityLevel = SeverityLevel.Error, Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } } });
		await this.AppInsights.Flush();
	}

	private void TrackGlobalException() {
		throw new NotImplementedException("Something wrong happened :(", new InvalidOperationException("TEST INNER"));
	}

	private async Task SetAuthenticatedUserContext() {
		await this.AppInsights.SetAuthenticatedUserContext("myUserId", "myUserName", true);
		await this.AppInsights.TrackEvent(new EventTelemetry() { Name = "Auth Event" });
		await this.AppInsights.Flush();
	}

	private async Task ClearAuthenticatedUserContext() {
		await this.AppInsights.SetAuthenticatedUserContext("myUserId", "myUserName", true);
		await this.AppInsights.TrackEvent(new EventTelemetry() { Name = "Auth Event" });
		await this.AppInsights.ClearAuthenticatedUserContext();
		await this.AppInsights.TrackEvent(new EventTelemetry() { Name = "Auth Event2" });
		await this.AppInsights.Flush();
	}

	private async Task StartStopTrackPage() {
		await this.AppInsights.StartTrackPage("myPage");
		await this.AppInsights.Flush();
		await Task.Delay(100);
		await this.AppInsights.StopTrackPage("myPage", customProperties: new Dictionary<string, object?>() { { "customProperty", "customValue" } });
		await this.AppInsights.Flush();
	}

	private async Task TrackDependencyData() {
		await this.AppInsights.TrackDependencyData(new DependencyTelemetry() {
			Id = "myId",
			Name = "myName",
			Duration = 1000,
			Success = true,
			StartTime = DateTime.Now,
			ResponseCode = 200,
			CorrelationContext = "myContext",
			Type = "myType",
			Data = "mydata",
			Target = "myTarget",
			Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } }
		});
		await this.AppInsights.Flush();
	}

	private async Task TrackMetric() {
		await this.AppInsights.TrackMetric(new MetricTelemetry() {
			Name = "myMetric",
			Average = 100,
			SampleCount = 200,
			Min = 1,
			Max = 200,
			Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } }
		});

		await this.AppInsights.Flush();
	}

	private async Task TrackPageView() {
		await this.AppInsights.TrackPageView(new PageViewTelemetry() {
			Name = "myPage",
			Uri = "https://test.local",
			RefUri = "https://test.local",
			PageType = "TestPage",
			IsLoggedIn = true,
			Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } }
		});
		await this.AppInsights.Flush();
	}

	private async Task TrackPageViewPerformance() {
		await this.AppInsights.TrackPageViewPerformance(new PageViewPerformanceTelemetry() {
			Name = "myPerf",
			Uri = "/test123",
			//DomProcessing = TimeSpan.FromSeconds(69),
			//Duration = TimeSpan.FromSeconds(69),
			//NetworkConnect = TimeSpan.FromSeconds(69),
			//PerfTotal = TimeSpan.FromSeconds(69),
			//ReceivedResponse = TimeSpan.FromSeconds(69),
			//SentRequest = TimeSpan.FromSeconds(69),
			Properties = new Dictionary<string, object?>() { { "customProperty", "customValue" } }
		});
		await this.AppInsights.Flush();
	}

	private async Task TestLogger() {
		this.Logger.LogInformation("My Logging Test");
		await this.AppInsights.Flush();
	}

	private async Task TestSemanticLogger() {
		this.Logger.LogInformation("My Semantic Logging Test with customProperty={customProperty}", "customValue");
		await this.AppInsights.Flush();
	}

	private async Task StartStopTrackEvent() {
		await this.AppInsights.StartTrackEvent("myEvent");
		await this.AppInsights.Flush();
		await this.AppInsights.StopTrackEvent("myEvent", new Dictionary<string, object?>() { { "customProperty", "customValue" } });
		await this.AppInsights.Flush();
	}

	private async Task TrackHttpRequest() {
		_ = await this.HttpClient.GetStringAsync("https://httpbin.org/get");
		await this.AppInsights.Flush();
	}

	private async Task GetUserId() {
		var ctx = await this.AppInsights.Context();

		if (ctx is null) {
			return;
		}

		this.UserId = ctx.User.AuthenticatedId ?? ctx.User.Id;
	}

	private async Task GetSessionId() {

		var ctx = await this.AppInsights.Context();

		if (ctx is null) {
			return;
		}

		this.SessionId = ctx.SessionManager.AutomaticSession.Id ?? Guid.NewGuid().ToString();

	}

	private async Task EnableCookies() {
		await this.AppInsights.GetCookieMgr().SetEnabled(true);
	}

	private async Task DisableCookies() {
		await this.AppInsights.GetCookieMgr().SetEnabled(false);
	}

	private async Task GetCookiesEnabled() {
		this.CookiesEnabled = await this.AppInsights.GetCookieMgr().IsEnabled();
	}
}