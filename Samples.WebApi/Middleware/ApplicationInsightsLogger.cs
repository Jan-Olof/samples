// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Samples.WebApi.Middleware
{
    /// <summary>
    /// Implementation of ILogger for ApplicationInsights.
    /// </summary>
    public class ApplicationInsightsLogger : ILogger
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _name;
        private readonly TelemetryClient _telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInsightsLogger"/> class.
        /// </summary>
        public ApplicationInsightsLogger(string name)
            : this(name, null, new ApplicationInsightsSettings())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInsightsLogger"/> class.
        /// </summary>
        public ApplicationInsightsLogger(string name, Func<string, LogLevel, bool> filter, ApplicationInsightsSettings settings)
        {
            _name = string.IsNullOrEmpty(name) ? nameof(ApplicationInsightsLogger) : name;
            _filter = filter;
            _telemetryClient = new TelemetryClient();

            if (settings.DeveloperMode.HasValue)
            {
                TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = settings.DeveloperMode;
            }

            if (settings.DeveloperMode != null && !settings.DeveloperMode.Value)
            {
                if (string.IsNullOrWhiteSpace(settings.InstrumentationKey))
                {
                    throw new ArgumentNullException(nameof(settings.InstrumentationKey));
                }

                TelemetryConfiguration.Active.InstrumentationKey = settings.InstrumentationKey;
                _telemetryClient.InstrumentationKey = settings.InstrumentationKey;
            }
        }

        /// <summary>
        /// Begin scope.
        /// </summary>
        public IDisposable BeginScope<TState>(TState state)
            => NoopDisposable.Instance;

        /// <summary>
        /// Is enabled.
        /// </summary>
        public bool IsEnabled(LogLevel logLevel)
            => (_filter == null || _filter(_name, logLevel));

        /// <summary>
        /// Turns a log message into something that fits into application insights.
        /// </summary>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (exception != null)
            {
                _telemetryClient.TrackException(new ExceptionTelemetry(exception));
                return;
            }

            string message = string.Empty;
            if (formatter != null)
            {
                message = formatter(state, null);
            }
            else
            {
                if (state != null)
                {
                    message += state;
                }
            }

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            //if (eventId.IsEvent())
            //{
            _telemetryClient.TrackEvent(eventId.Name, CreateEventIdDictionary(eventId, message));

            // TODO: Add track id.
            // var loggingMessage = LoggingMessage.CreateLoggingMessage(message);
            // _telemetryClient.TrackEvent(eventId.Name, CreateEventIdDictionary(eventId, loggingMessage.Message, loggingMessage.TrackId));
            //}
            //else
            //{
            //_telemetryClient.TrackTrace(message, GetSeverityLevel(logLevel), CreateEventIdDictionary(eventId, message));
            //}
        }

        private static IDictionary<string, string> CreateEventIdDictionary(EventId eventId)
            => new Dictionary<string, string>
            {
                { "EventId", eventId.Id.ToString() },
                { "EventName", eventId.Name }
            };

        private static IDictionary<string, string> CreateEventIdDictionary(EventId eventId, string msg)
        {
            var dic = CreateEventIdDictionary(eventId);
            dic.Add("Message", msg);

            return dic;
        }

        private static IDictionary<string, string> CreateEventIdDictionary(EventId eventId, string msg, string trackId)
        {
            var dic = CreateEventIdDictionary(eventId, msg);
            dic.Add("TrackId", trackId);

            return dic;
        }

        private static SeverityLevel GetSeverityLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical: return SeverityLevel.Critical;
                case LogLevel.Error: return SeverityLevel.Error;
                case LogLevel.Warning: return SeverityLevel.Warning;
                case LogLevel.Information: return SeverityLevel.Information;
                default: return SeverityLevel.Verbose;
            }
        }

        private class NoopDisposable : IDisposable
        {
            public static readonly NoopDisposable Instance = new NoopDisposable();

            public void Dispose()
            {
            }
        }
    }
}