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
        public static readonly SqlTemplate InsertIntoBookTransfers = "INSERT INTO [dbo].[BookTransfers]([Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        /// <summary>
        /// Persist a transfer to the database.
        /// </summary>
        public static Exceptional<Unit> Save(this BookTransferDao transfer, Func<object, int> insert)
        {
            try
            {
                insert(transfer);
            }
            catch (Exception ex)
            {
                return ex;
            }

            return Unit();
        }
    }
}