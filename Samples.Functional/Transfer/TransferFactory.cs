using LaYumba.Functional;
using Samples.Functional.Transfer.Entities;
using System;

namespace Samples.Functional.Transfer
{
    public static class TransferFactory
    {
        public static Validation<BookTransfer> CreateBookTransfer(this BookTransferDto cmd, Func<DateTime> now)
            => BookTransfer.Of(now, cmd.Amount, cmd.Beneficiary, cmd.Bic, cmd.Date, cmd.DebitedAccountId, cmd.Iban, cmd.Reference, cmd.Timestamp);

        public static BookTransferDto CreateBookTransferDto(this BookTransfer bookTransfer)
            => new BookTransferDto
            {
                Amount = bookTransfer.AmountToTransfer.Value,
                Beneficiary = bookTransfer.BeneficiaryOfTransfer.Value,
                Bic = bookTransfer.BicCode.Value,
                Date = bookTransfer.DateOfTransfer.Value,
                DebitedAccountId = bookTransfer.DebitedAccountId.Value.ToString(),
                Iban = bookTransfer.InternationalBankAccountNumber.Value,
                Reference = bookTransfer.ReferenceOfTransfer.Value,
                Timestamp = bookTransfer.TimestampOfTransfer.Value
            };
    }
}