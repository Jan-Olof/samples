using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Handle(this BookTransferDto transfer, Func<DateTime> now, ConnectionString connString)
            => transfer
                .CreateBookTransfer(now)
                .Map(t => t
                    .CreateBookTransferDao()
                    .Save(connString));
    }
}