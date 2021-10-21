using System;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Redbridge.Configuration;

namespace Redbridge.Diagnostics.ApplicationInsights
{
    public class ApplicationInsightsContextInitializer : ITelemetryInitializer
    {
        private readonly IApplicationSettingsRepository _settings;

        public ApplicationInsightsContextInitializer(IApplicationSettingsRepository settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.GlobalProperties["tags"] = _settings.GetStringValue("ApplicationInsights:Tags");
        }
    }
}