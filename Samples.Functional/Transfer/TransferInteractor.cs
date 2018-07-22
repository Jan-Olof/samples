using LaYumba.Functional;
using System;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Handle(this BookTransferDto cmd, Func<DateTime> now, string connString)
        {
            return cmd.CreateBookTransfer(now)
                .Map(transfer => transfer
                    .CreateBookTransferDao()
                    .Save(connString));
        }
    }
}