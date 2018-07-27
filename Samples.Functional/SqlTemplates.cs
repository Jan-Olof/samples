using Samples.Functional.Helpers;

namespace Samples.Functional
{
    public class Sql // TODO:
    {
        //public static readonly SqlTemplate InsertIntoBookTransfers = $"{InsertInto} {BookTransfers}({BookTransferColumns}) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        private const string BookTransferColumns = "[Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]";

        private const string BookTransfers = "[dbo].[BookTransfers]";

        private const string InsertInto = "INSERT INTO";

        private static string BookTransferColumnsWithId = $"[Id],{BookTransferColumns}";

        public static SqlTemplate InsertIntoBookTransfers => $"{InsertInto} {BookTransfers}({BookTransferColumns}) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        public static SqlTemplate SelectBookTransferFromId => $"{SelectBookTransfers} WHERE Id=@Id";

        public static SqlTemplate SelectBookTransfers => $"SELECT {BookTransferColumnsWithId} FROM {BookTransfers}";
    }
}