using Samples.Functional.Helpers;

namespace Samples.Functional
{
    public static class SqlTemplates
    {
        public static readonly SqlTemplate InsertIntoBookTransfers = $"{InsertInto} [dbo].[BookTransfers]([Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        private static readonly string InsertInto = "INSERT INTO";
    }
}