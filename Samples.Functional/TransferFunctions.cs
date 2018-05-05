using LaYumba.Functional;
using System;
using System.Text.RegularExpressions;
using static LaYumba.Functional.F;

namespace Samples.Functional
{
    /// <summary>
    /// Functions for BookTransfer.
    /// </summary>
    public static class TransferFunctions
    {
        /// <summary>
        /// Bic code validation.
        /// </summary>
        public static Validation<BookTransfer> ValidateBic(this BookTransfer cmd, Regex regex)
            => Some(cmd)
                .Where(transfer => regex.IsMatch(transfer.Bic.ToUpper()))
                .Match<Validation<BookTransfer>>(() => Errors.InvalidBic, transfer => transfer);

        /// <summary>
        /// Date validation.
        /// </summary>
        public static Validation<BookTransfer> ValidateDate(this BookTransfer cmd, DateTime now)
            => Some(cmd)
                .Where(transfer => transfer.Date.Date > now.Date)
                .Match<Validation<BookTransfer>>(() => Errors.TransferDateIsPast, transfer => transfer);
    }
}