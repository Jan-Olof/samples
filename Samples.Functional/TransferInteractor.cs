using Dapper;
using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace Samples.Functional
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Handle(this BookTransfer cmd, DateTime now, string connString)
            => cmd.Validate(now)
                .Map(c => c.Save(connString));

        // persistence TODO: Move
        private static Exceptional<Unit> Save(this BookTransfer transfer, string connString)
        {
            try
            {
                ConnectionHelper.Connect(connString, c => c.Execute("INSERT ...", transfer));
            }
            catch (Exception ex) { return ex; }
            return Unit();
        }

        private static Validation<BookTransfer> Validate(this BookTransfer cmd, DateTime now)
            => cmd.ValidateBic(Settings.BicCodeRegex())
                .Bind(c => c.ValidateDate(now));
    }
}