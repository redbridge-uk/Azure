using System;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Redbridge.Diagnostics.ApplicationInsights.Filters
{
    /// <summary>
    /// This filter will remove any app insight entries for AcceptMessageSession that time out until MS do their bit.
    /// </summary>
    public class ServiceBusAcceptMessageSessionDependencyFilter : ApplicationInsightsDependencyFilter
    {
        public ServiceBusAcceptMessageSessionDependencyFilter(ITelemetryProcessor next) : base(next) { }

        protected override bool OnShouldFilterDependencyTelemetry(DependencyTelemetry dependency)
        {
            return dependency.Type.Equals("AcceptMessageSession", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}