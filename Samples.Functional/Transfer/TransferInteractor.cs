using LaYumba.Functional;
using System;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Create(this BookTransferDto transfer, Func<DateTime> now, Func<object, int> insert)
            => transfer
                .CreateBookTransfer(now)
                .Map(t => t
                    .CreateBookTransferDao()
                    .Save(insert));
    }
}