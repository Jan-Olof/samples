using LaYumba.Functional;
using System;

using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct Timestamp
    {
        private Timestamp(DateTime value)
            => Value = value;

        public DateTime Value { get; }

        public static Validation<Timestamp> Of(DateTime timestamp, Func<DateTime> now)
            => IsValid(timestamp, now)
                ? Valid(new Timestamp(timestamp))
                : Invalid(Errors.InvalidTimestamp);

        private static bool IsValid(DateTime timestamp, Func<DateTime> now)
            => timestamp < now();
    }
}