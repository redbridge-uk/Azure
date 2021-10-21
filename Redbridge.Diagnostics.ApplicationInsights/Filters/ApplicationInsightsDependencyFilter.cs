using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Redbridge.Diagnostics.ApplicationInsights.Filters
{
    public abstract class ApplicationInsightsDependencyFilter : ITelemetryProcessor
    {
        private ITelemetryProcessor Next { get; }

        // next will point to the next TelemetryProcessor in the chain.
        protected ApplicationInsightsDependencyFilter(ITelemetryProcessor next)
        {
            Next = next;
        }

        public void Process(ITelemetry item)
        {
            // To filter out an item, return without calling the next processor.
            // So if we are planning to filter it, then just return.
            if (ShouldFilter(item)) { return; }

            Next.Process(item);
        }

        // Example: replace with your own criteria.
        private bool ShouldFilter(ITelemetry item)
        {
            // We are trying to filter out a dependency, if it's not a dependency then don't filter it.
            if (!(item is DependencyTelemetry dependency))
            {
                // It's not a dependency telemetry event so don't filter it.
                return false;
            }

            // It is a dependency telemetry event so let the inheriting filter decide.
            return OnShouldFilterDependencyTelemetry(dependency);
        }

        protected abstract bool OnShouldFilterDependencyTelemetry(DependencyTelemetry dependency);
    }
}
