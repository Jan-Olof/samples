using System;

namespace Samples.Functional.Transfer
{
    public class BookTransferDao // TODO: More immutable stuff (with). Private constructor and factory methods.
    {
        [Obsolete("Default constructor only here for the ORM", true)]
        public BookTransferDao()
        {
        }

        public BookTransferDao(decimal amount, string beneficiary, string bic, DateTime date, Guid debitedAccountId, string iban, int id, string reference, DateTime timestamp)
        {
            Amount = amount;
            Beneficiary = beneficiary;
            Bic = bic;
            Date = date;
            DebitedAccountId = debitedAccountId;
            Iban = iban;
            Id = id;
            Reference = reference;
            Timestamp = timestamp;
        }

        public decimal Amount { get; }
        public string Beneficiary { get; }
        public string Bic { get; }
        public DateTime Date { get; }
        public Guid DebitedAccountId { get; }
        public string Iban { get; }
        public int Id { get; }
        public string Reference { get; }
        public DateTime Timestamp { get; }
    }
}