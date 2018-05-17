//using Dapper;
//using LaYumba.Functional;
//using System;
//using static LaYumba.Functional.F;
//using Unit = System.ValueTuple;

//namespace Samples.Functional
//{
//    public static class TransferInteractor
//    {
//        public static Validation<Exceptional<Unit>> Handle(this BookTransferDto cmd, DateTime now, string connString)
//        {
//            return cmd.Validate(now)
//                .Map(c => c.Save(connString));
//        }

//        // persistence TODO: Move
//        private static Exceptional<Unit> Save(this BookTransfer transfer, string connString)
//        {
//            try
//            {
//                ConnectionHelper.Connect(connString, c => c.Execute("INSERT INTO... ", transfer)); //TODO: Fix!
//            }
//            catch (Exception ex) { return ex; }
//            return Unit();
//        }

//        private static Validation<BookTransfer> Validate(this BookTransfer cmd, DateTime now)
//            => cmd.ValidateBic(Settings.BicCodeRegex())
//                .Bind(c => c.ValidateDate(now));

//        // TODO: Create new "transfer" data objects instead of the ones used now (that are DTOs).
//    }
//}