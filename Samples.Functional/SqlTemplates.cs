using Samples.Functional.Helpers;
using System;

namespace Samples.Functional
{
    public class Sql // TODO:
    {
        //public static readonly SqlTemplate InsertIntoBookTransfers = $"{InsertInto} {BookTransfers}({BookTransferColumns}) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        private const string BookTransferColumns = "[Amount],[Beneficiary],[Bic],[Date],[DebitedAccountId],[Iban],[Reference],[Timestamp]";

        private const string BookTransfers = "[dbo].[BookTransfers]";

        private const string InsertInto = "INSERT INTO";

        private static string BookTransferColumnsWithId = $"[Id],{BookTransferColumns}";

        private static SqlTemplate InsertIntoBookTransfers => $"{InsertInto} {BookTransfers}({BookTransferColumns}) VALUES(@Amount,@Beneficiary,@Bic,@Date,@DebitedAccountId,@Iban,@Reference,@Timestamp)";

        private static SqlTemplate SelectBookTransferFromIban => $"{SelectBookTransfers} WHERE Iban=@Iban";

        private static SqlTemplate SelectBookTransferFromId => $"{SelectBookTransfers} WHERE Id=@Id";

        private static SqlTemplate SelectBookTransfers => $"SELECT {BookTransferColumnsWithId} FROM {BookTransfers}";

        public static SqlTemplate GetSqlTemplate(SqlEnum t)
        {
            switch (t)
            {
                case SqlEnum.InsertIntoBookTransfers:
                    return InsertIntoBookTransfers;

                case SqlEnum.SelectBookTransfers:
                    return SelectBookTransfers;

                case SqlEnum.SelectBookTransferFromId:
                    return SelectBookTransferFromId;

                case SqlEnum.SelectBookTransferFromIban:
                    return SelectBookTransferFromIban;

                default:
                    throw new ArgumentOutOfRangeException("t");
            }
        }
    }
}