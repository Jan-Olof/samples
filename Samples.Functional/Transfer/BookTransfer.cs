using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Amount amount, TransferDate date)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
        }

        public Amount AmountToTransfer { get; }

        public TransferDate DateOfTransfer { get; }

        public static Validation<BookTransfer> Of(
            DateTime dateOfTransfer,
            Func<DateTime> now,
            decimal amountToTransfer)
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);

            return IsValid(amount, date)
                ? Valid(new BookTransfer(amount.GetValidObject(), date.GetValidObject()))
                : Invalid(GetErrors(amount, date));
        }

        private static IEnumerable<Error> GetErrors(Validation<Amount> amount, Validation<TransferDate> date)
            => new List<Error>()
                .AddMany(amount.GetErrors())
                .AddMany(date.GetErrors());

        private static bool IsValid(Validation<Amount> amount, Validation<TransferDate> date)
            => amount.IsValid && date.IsValid;
    }
}