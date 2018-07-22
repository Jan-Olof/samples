using LaYumba.Functional;
using Samples.Functional.Transfer.Entities;
using System;

namespace Samples.Functional.Transfer
{
    public static class TransferFactory
    {
        public static Validation<BookTransfer> CreateBookTransfer(this BookTransferDto cmd, Func<DateTime> now)
            => BookTransfer.Of(now, cmd.Amount, cmd.Beneficiary, cmd.Bic, cmd.Date, cmd.DebitedAccountId, cmd.Iban, cmd.Reference, cmd.Timestamp);

        public static BookTransferDao CreateBookTransferDao(this BookTransfer bookTransfer)
            => new BookTransferDao(
                bookTransfer.AmountToTransfer.Value,
                bookTransfer.BeneficiaryOfTransfer.Value,
                bookTransfer.BicCode.Value,
                bookTransfer.DateOfTransfer.Value,
                bookTransfer.DebitedAccountId.Value,
                bookTransfer.InternationalBankAccountNumber.Value,
                bookTransfer.ReferenceOfTransfer.Value,
                bookTransfer.TimestampOfTransfer.Value);

        public static BookTransferDto CreateBookTransferDto(this BookTransfer bookTransfer)
            => new BookTransferDto(
                bookTransfer.AmountToTransfer.Value,
                bookTransfer.BeneficiaryOfTransfer.Value,
                bookTransfer.BicCode.Value,
                bookTransfer.DateOfTransfer.Value,
                bookTransfer.DebitedAccountId.Value.ToString(),
                bookTransfer.InternationalBankAccountNumber.Value,
                bookTransfer.ReferenceOfTransfer.Value,
                bookTransfer.TimestampOfTransfer.Value);
    }
}