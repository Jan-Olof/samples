using System;

namespace Samples.Utilities
{
    /// <summary>
    /// Use this class instead of DateTime to get better testability.
    /// </summary>
    public class SystemTime
    {
        /// <summary>
        /// The date.
        /// </summary>
        private static DateTime _date;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTime"/> class.
        /// </summary>
        public SystemTime() => _date = DateTime.MinValue;

        /// <summary>
        /// Gets the default date time value.
        /// </summary>
        public static DateTime DateTimeDefault => new DateTime(1900, 1, 1);

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on this computer.
        /// </summary>
        public static DateTime Now => _date != DateTime.MinValue ? _date : DateTime.Now;

        /// <summary>
        /// Reset date to min value.
        /// </summary>
        public static void Reset() => _date = DateTime.MinValue;

        /// <summary>
        /// Set a custom DateTime value.
        /// </summary>
        public static void Set(DateTime custom) => _date = custom;
    }
}