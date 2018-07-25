using Samples.Functional.Helpers;

namespace Samples.Functional
{
    public static class SqlTemplates
    {
        public static readonly SqlTemplate InsertIntoBookTransfers = $"{InsertInto} [dbo].[BookTransfers]([Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        public static readonly SqlTemplate q = "SELECT * FROM [dbo].[BookTransfers] WHERE Id=@Id"; // TODO: Continue with this

        private static readonly string InsertInto = "INSERT INTO";
    }
}