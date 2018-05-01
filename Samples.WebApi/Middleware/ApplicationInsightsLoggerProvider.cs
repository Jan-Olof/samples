using Microsoft.Extensions.Logging;
using System;

namespace Samples.WebApi.Middleware
{
    /// <summary>
    /// ApplicationInsightsLoggerProvider
    /// </summary>
    public class ApplicationInsightsLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly ApplicationInsightsSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInsightsLoggerProvider" /> class.
        /// </summary>
        public ApplicationInsightsLoggerProvider(Func<string, LogLevel, bool> filter, ApplicationInsightsSettings settings)
        {
            _filter = filter;
            _settings = settings;
        }

        /// <summary>
        /// Create logger.
        /// </summary>
        public ILogger CreateLogger(string name)
            => new ApplicationInsightsLogger(name, _filter, _settings);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}