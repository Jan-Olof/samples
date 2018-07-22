using Dapper;
using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferPersistence
    {
        // TODO: Move
        private static readonly string ins = "INSERT INTO [dbo].[BookTransfers]([Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        /// <summary>
        /// Persist a transfer to the database.
        /// </summary>
        public static Exceptional<Unit> Save(this BookTransferDao transfer, string connString)
        {
            try
            {
                ConnectionHelper.Connect(connString, c => c.Execute(ins, transfer)); //TODO: Fix!
            }
            catch (Exception ex)
            {
                return ex;
            }

            return Unit();
        }
    }
}