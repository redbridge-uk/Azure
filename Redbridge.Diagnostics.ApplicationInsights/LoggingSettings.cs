namespace Redbridge.Diagnostics.ApplicationInsights
{
    public class LoggingSettings
    {
        /// <summary>
        /// Use auto flush for console based applications such as webjobs who do not always exit gracefully.
        /// </summary>
        public bool AutoFlush { get; set; } = false;
        public bool DuplicateToConsole { get; set; } = false;
        public static LoggingSettings Default => new LoggingSettings() { AutoFlush = false };
    }
}