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

        public static Option<TransferDate> Of(DateTime transferDate, DateTime now)
            => IsValid(transferDate, now) ? Some(new TransferDate(transferDate)) : None;

        private static bool IsValid(DateTime transferDate, DateTime now)
            => transferDate.Date > now.Date;
    }
}