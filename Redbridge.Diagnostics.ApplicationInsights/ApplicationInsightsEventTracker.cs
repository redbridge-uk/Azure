using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;

namespace Redbridge.Diagnostics.ApplicationInsights
{
    public class ApplicationInsightsEventTracker : IEventTracker
    {
        private readonly TelemetryClient _client;
        private readonly LoggingSettings _settings;

        public ApplicationInsightsEventTracker(TelemetryClient client, LoggingSettings settings)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void WriteEvent(string eventName, IDictionary<string, string> properties = null)
        {
            if (_settings.DuplicateToConsole)
            {
                Console.WriteLine($"*** Tracked event {eventName} ***");
            }

            _client.TrackEvent(eventName, properties);
            _client.Flush();
        }
    }
}