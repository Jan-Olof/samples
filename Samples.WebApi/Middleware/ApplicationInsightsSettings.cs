namespace Samples.WebApi.Middleware
{
    /// <summary>
    /// ApplicationInsightsSettings
    /// </summary>
    public class ApplicationInsightsSettings
    {
        /// <summary>
        /// Developer mode.
        /// </summary>
        public bool? DeveloperMode { get; set; }

        /// <summary>
        /// Instrumentation key.
        /// </summary>
        public string InstrumentationKey { get; set; }
    }
}