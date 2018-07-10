using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Amount amount, TransferDate date, Beneficiary beneficiary, Bic bicCode)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
            BeneficiaryOfTransfer = beneficiary;
            BicCode = bicCode;
        }

        public Amount AmountToTransfer { get; }
        public Beneficiary BeneficiaryOfTransfer { get; }
        public Bic BicCode { get; }
        public TransferDate DateOfTransfer { get; }

        public static Validation<BookTransfer> Of(
            DateTime dateOfTransfer,
            Func<DateTime> now,
            decimal amountToTransfer,
            string beneficiaryOfTransfer,
            string bicCode)
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);
            var beneficiary = Beneficiary.Of(beneficiaryOfTransfer);
            var bic = Bic.Of(bicCode);

            return IsValid(amount, date, beneficiary, bic)
                ? Valid(new BookTransfer(amount.GetValidObject(), date.GetValidObject(), beneficiary.GetValidObject(), bic.GetValidObject()))
                : Invalid(GetErrors(amount, date, beneficiary, bic));
        }

        private static IEnumerable<Error> GetErrors(
            Validation<Amount> amount,
            Validation<TransferDate> date,
            Validation<Beneficiary> beneficiary,
            Validation<Bic> bic)
            => new List<Error>()
                .AddMany(amount.GetErrors())
                .AddMany(date.GetErrors())
                .AddMany(beneficiary.GetErrors())
                .AddMany(bic.GetErrors());

        private static bool IsValid(
            Validation<Amount> amount,
            Validation<TransferDate> date,
            Validation<Beneficiary> beneficiary,
            Validation<Bic> bic)
            => amount.IsValid && date.IsValid && beneficiary.IsValid && bic.IsValid;
    }
}