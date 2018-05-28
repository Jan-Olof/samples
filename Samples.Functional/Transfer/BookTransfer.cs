using LaYumba.Functional;
using System;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Option<TransferDate> date, Option<Amount> amount)
        {
            DateOfTransfer = date;
            AmountToTransfer = amount;
        }

        public Option<Amount> AmountToTransfer { get; }

        public Option<TransferDate> DateOfTransfer { get; }

        public static BookTransfer Of(
            DateTime dateOfTransfer,
            DateTime now,
            decimal amountToTransfer)
        {
            var date = TransferDate.Of(dateOfTransfer, now);
            var amount = Amount.Of(amountToTransfer);

            return new BookTransfer(date, amount);
        }
    }
}