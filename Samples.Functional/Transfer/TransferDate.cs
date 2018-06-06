using LaYumba.Functional;
using System;

using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct TransferDate
    {
        private TransferDate(DateTime value)
            => Value = value;

        private DateTime Value { get; }

        public static Validation<TransferDate> Of(DateTime transferDate, Func<DateTime> now)
            => IsValid(transferDate, now)
                ? Valid(new TransferDate(transferDate))
                : Invalid(Errors.TransferDateIsPast);

        private static bool IsValid(DateTime transferDate, Func<DateTime> now)
            => transferDate.Date > now().Date;
    }
}