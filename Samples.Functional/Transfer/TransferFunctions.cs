using LaYumba.Functional;
using System;
using System.Text.RegularExpressions;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    /// <summary>
    /// Functions for BookTransfer. (These are obsolete, but useful to show an another way of doing things.)
    /// </summary>
    public static class TransferFunctions
    {
        /// <summary>
        /// Bic code validation.
        /// </summary>
        public static Validation<BookTransferDto> ValidateBic(this BookTransferDto transfer, Regex regex)
            => Some(transfer)
                .Where(t => regex.IsMatch(t.Bic.ToUpper()))
                .Match<Validation<BookTransferDto>>(() => Errors.InvalidBic, t => t);

        /// <summary>
        /// Date validation.
        /// </summary>
        public static Validation<BookTransferDto> ValidateDate(this BookTransferDto transfer, DateTime now)
            => Some(transfer)
                .Where(t => t.Date.Date > now.Date)
                .Match<Validation<BookTransferDto>>(() => Errors.TransferDateIsPast, t => t);
    }
}