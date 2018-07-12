using LaYumba.Functional;
using System;

namespace Samples.Functional.Transfer.Entities
{
    public struct TransferDate
    {
        private TransferDate(DateTime value)
            => Value = value;

        public DateTime Value { get; }

        public static Validation<TransferDate> Of(DateTime transferDate, Func<DateTime> now)
                    => IsValid(transferDate, now)
                ? F.Valid(new TransferDate(transferDate))
                : F.Invalid(Errors.TransferDateIsPast);

        private static bool IsValid(DateTime transferDate, Func<DateTime> now)
            => transferDate.Date > now().Date;
    }
}