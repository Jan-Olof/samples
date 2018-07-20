using Dapper;
using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Handle(this BookTransferDto cmd, Func<DateTime> now, string connString)
        {
            return cmd.CreateBookTransfer(now)
                .Map(transfer => transfer
                    .CreateBookTransferDto()
                    .Save(connString));
        }

        // persistence TODO: Move to TransferPersistance
        private static Exceptional<Unit> Save(this BookTransferDto transfer, string connString)
        {
            try
            {
                ConnectionHelper.Connect(connString, c => c.Execute("INSERT INTO... ", transfer)); //TODO: Fix!
            }
            catch (Exception ex) { return ex; }
            return Unit();
        }

        //private static Validation<BookTransfer> Validate(this BookTransfer cmd, DateTime now)
        //    => cmd.ValidateBic(Settings.BicCodeRegex())
        //        .Bind(c => c.ValidateDate(now));
    }
}