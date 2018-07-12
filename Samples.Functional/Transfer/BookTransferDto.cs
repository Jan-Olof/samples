using System;

namespace Samples.Functional.Transfer
{
    public class BookTransferDto
    {
        public decimal Amount { get; set; }
        public string Beneficiary { get; set; }
        public string Bic { get; set; }
        public DateTime Date { get; set; }
        public string DebitedAccountId { get; set; }
        public string Iban { get; set; }
        public string Reference { get; set; }
        public DateTime Timestamp { get; set; }
    }
}