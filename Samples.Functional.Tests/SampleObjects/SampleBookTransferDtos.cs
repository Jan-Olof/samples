using Samples.Functional.Transfer;
using System;

namespace Samples.Functional.Tests.SampleObjects
{
    public static class SampleBookTransferDtos
    {
        public static BookTransferDto CreateBookTransferDto(DateTime date, string bic = "bicbac1bec9")
            => new BookTransferDto
            {
                Amount = 10000,
                Date = date,
                Beneficiary = "bla",
                Bic = bic,
                DebitedAccountId = "853a2670-506b-4dcf-8cda-79f2f58d1f92",
                Iban = "iban",
                Reference = "ref",
                Timestamp = new DateTime(2000, 1, 1)
            };
    }
}