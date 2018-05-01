using System;

namespace Samples.WebApi.Dtos
{
    /// <summary>
    /// The Http error class.
    /// </summary>
    public class HttpError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpError" /> class.
        /// </summary>
        public HttpError()
        {
            ExceptionMessage = string.Empty;
            ExceptionType = string.Empty;
            StackTrace = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpError" /> class.
        /// </summary>
        public HttpError(Exception exception)
        {
            ExceptionMessage = exception.Message;
            ExceptionType = exception.GetType().FullName;
            StackTrace = exception.StackTrace;
        }

        /// <summary>
        /// Gets or sets the ExceptionMessage.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the ExceptionType.
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// Gets or sets the StackTrace.
        /// </summary>
        public string StackTrace { get; set; }
    }
}