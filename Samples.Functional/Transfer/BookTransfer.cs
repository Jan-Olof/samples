using LaYumba.Functional;
using System;

namespace Samples.Functional.Transfer
{
    public struct BookTransfer
    {
        private BookTransfer(Option<TransferDate> date)
        {
            Date = date;
        }

        public Option<TransferDate> Date { get; }

        public static BookTransfer Of(DateTime transferDate, DateTime now)
        {
            var date = TransferDate.Of(transferDate, now);

            return new BookTransfer(date);
        }
    }
}