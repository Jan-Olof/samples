using LaYumba.Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Validation<TransferDate> date, Validation<Amount> amount)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
        }

        public Validation<Amount> AmountToTransfer { get; } // TODO: Change to Amount

        public Validation<TransferDate> DateOfTransfer { get; } // TODO: Change to TransferDate

        public static Validation<BookTransfer> Of(
            DateTime dateOfTransfer,
            Func<DateTime> now,
            decimal amountToTransfer)
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);

            // TODO: Use IsValid to see if all are valid. Return errors if not valid.

            // Use this if not valid.
            var e = new List<Error>();
            e = date.Match(n => e.AddMany(n).ToList(), d => e);

            // If valid change types.
            return new BookTransfer(date, amount);
        }
    }
}