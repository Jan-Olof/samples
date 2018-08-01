using Microsoft.Extensions.Logging;
using Samples.FunctionalWebApi.Controllers;
using System;

namespace Samples.FunctionalWebApi.Tests
{
    public class FakeLogger : ILogger<TransferController>
    {
        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) => true;

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        { }
    }
}