using LaYumba.Functional;
using Samples.Functional.Transfer.Entities;
using System;

namespace Samples.Functional.Transfer
{
    public static class TransferFactory
    {
        public static Validation<BookTransfer> CreateBookTransfer(this BookTransferDto cmd, Func<DateTime> now)
            => BookTransfer.Of(now, cmd.Amount, cmd.Beneficiary, cmd.Bic, cmd.Date);
    }
}