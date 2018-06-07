using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(TransferDate date, Amount amount)
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
                ? Valid(new BookTransfer(date.GetValidObject(), amount.GetValidObject()))
                : Invalid(new List<Error>()); // TODO: Fix this!!!

            //// Use this if not valid.
            //var e = new List<Error>();
            //e = date.Match(n => e.AddMany(n).ToList(), d => e);
        }

        //private static IEnumerable<Error> GetErrors(Validation<Amount> amount, Validation<TransferDate> date)
        //{
        //}

        private static bool IsValid(Validation<Amount> amount, Validation<TransferDate> date)
            => amount.IsValid && date.IsValid;
    }
}