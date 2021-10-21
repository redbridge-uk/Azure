using Microsoft.ApplicationInsights.Extensibility;
using Redbridge.Configuration;

namespace Redbridge.Diagnostics.ApplicationInsights
{
    public static class ApplicationInsightsTelemetryInstaller
	{
		public static void Install(IApplicationSettingsRepository settings)
		{
			TelemetryConfiguration.Active.InstrumentationKey = settings.GetStringValue("ApplicationInsights:Key");
		}
	}
}
