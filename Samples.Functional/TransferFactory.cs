using LaYumba.Functional;
using Samples.Functional.Transfer;
using System;

namespace Samples.Functional
{
    public static class TransferFactory
    {
        public static Validation<BookTransfer> CreateBookTransfer(this BookTransferDto cmd, Func<DateTime> now)
            => BookTransfer.Of(cmd.Date, now, cmd.Amount, cmd.Beneficiary);
    }
}