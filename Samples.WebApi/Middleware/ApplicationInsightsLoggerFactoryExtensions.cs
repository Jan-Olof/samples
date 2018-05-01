using Microsoft.Extensions.Logging;
using System;

namespace Samples.WebApi.Middleware
{
    /// <summary>
    /// ApplicationInsightsLoggerFactoryExtensions
    /// </summary>
    public static class ApplicationInsightsLoggerFactoryExtensions
    {
        /// <summary>
        /// Add application insights.
        /// </summary>
        public static ILoggerFactory AddApplicationInsights(
            this ILoggerFactory factory,
            Func<string, LogLevel, bool> filter,
            ApplicationInsightsSettings settings)
        {
            factory.AddProvider(new ApplicationInsightsLoggerProvider(filter, settings));
            return factory;
        }

        /// <summary>
        /// Add application insights.
        /// </summary>
        public static ILoggerFactory AddApplicationInsights(
            this ILoggerFactory factory,
            ApplicationInsightsSettings settings)
        {
            factory.AddProvider(new ApplicationInsightsLoggerProvider(null, settings));

            return factory;
        }
    }
}