using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct BookTransfer
    {
        private BookTransfer(Amount amount, TransferDate date, Beneficiary beneficiary, Bic bic, AccountId accountId)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
            BeneficiaryOfTransfer = beneficiary;
            BicCode = bic;
            DebitedAccountId = accountId;
        }

        public Amount AmountToTransfer { get; }
        public Beneficiary BeneficiaryOfTransfer { get; }
        public Bic BicCode { get; }
        public TransferDate DateOfTransfer { get; }
        public AccountId DebitedAccountId { get; }

        public static Validation<BookTransfer> Of(
            Func<DateTime> now,
            decimal amountToTransfer,
            string beneficiaryOfTransfer,
            string bicCode,
            DateTime dateOfTransfer,
            string debitedAccountId
            )
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);
            var beneficiary = Beneficiary.Of(beneficiaryOfTransfer);
            var bic = Bic.Of(bicCode);
            var accountId = AccountId.Of(debitedAccountId);

            return IsValid(amount, date, beneficiary, bic, accountId)
                ? Valid(new BookTransfer(amount.GetObject(), date.GetObject(), beneficiary.GetObject(), bic.GetObject(), accountId.GetObject()))
                : Invalid(GetErrors(amount, date, beneficiary, bic, accountId));
        }

        private static IEnumerable<Error> GetErrors(
            Validation<Amount> amount,
            Validation<TransferDate> date,
            Validation<Beneficiary> beneficiary,
            Validation<Bic> bic,
            Validation<AccountId> accountId)
                => new List<Error>()
                    .AddMany(amount.GetErrors())
                    .AddMany(date.GetErrors())
                    .AddMany(beneficiary.GetErrors())
                    .AddMany(bic.GetErrors())
                    .AddMany(accountId.GetErrors());

        private static bool IsValid(
            Validation<Amount> amount,
            Validation<TransferDate> date,
            Validation<Beneficiary> beneficiary,
            Validation<Bic> bic,
            Validation<AccountId> accountId)
                => amount.IsValid && date.IsValid && beneficiary.IsValid && bic.IsValid && accountId.IsValid;
    }
}