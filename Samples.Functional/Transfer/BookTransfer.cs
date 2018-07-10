using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Amount amount, TransferDate date, Beneficiary beneficiary)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
            BeneficiaryOfTransfer = beneficiary;
        }

        public Amount AmountToTransfer { get; }
        public Beneficiary BeneficiaryOfTransfer { get; }
        public TransferDate DateOfTransfer { get; }

        public static Validation<BookTransfer> Of(
            DateTime dateOfTransfer,
            Func<DateTime> now,
            decimal amountToTransfer,
            string beneficiaryOfTransfer)
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);
            var beneficiary = Beneficiary.Of(beneficiaryOfTransfer);

            return IsValid(amount, date, beneficiary)
                ? Valid(new BookTransfer(amount.GetValidObject(), date.GetValidObject(), beneficiary.GetValidObject()))
                : Invalid(GetErrors(amount, date, beneficiary));
        }

        private static IEnumerable<Error> GetErrors(Validation<Amount> amount, Validation<TransferDate> date, Validation<Beneficiary> beneficiary)
            => new List<Error>()
                .AddMany(amount.GetErrors())
                .AddMany(date.GetErrors())
                .AddMany(beneficiary.GetErrors());

        private static bool IsValid(Validation<Amount> amount, Validation<TransferDate> date, Validation<Beneficiary> beneficiary)
            => amount.IsValid && date.IsValid && beneficiary.IsValid;
    }
}