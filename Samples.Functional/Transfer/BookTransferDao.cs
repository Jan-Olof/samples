using System;

namespace Samples.Functional.Transfer
{
    public class BookTransferDao
    {
        public BookTransferDao(decimal amount, string beneficiary, string bic, DateTime date, string debitedAccountId, string iban, string reference, DateTime timestamp)
        {
            Amount = amount;
            Beneficiary = beneficiary;
            Bic = bic;
            Date = date;
            DebitedAccountId = debitedAccountId;
            Iban = iban;
            Reference = reference;
            Timestamp = timestamp;
        }

        public decimal Amount { get; }
        public string Beneficiary { get; }
        public string Bic { get; }
        public DateTime Date { get; }
        public string DebitedAccountId { get; }
        public string Iban { get; }
        public string Reference { get; }
        public DateTime Timestamp { get; }
    }
}