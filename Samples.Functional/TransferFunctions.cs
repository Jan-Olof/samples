using LaYumba.Functional;
using System;
using System.Text.RegularExpressions;

namespace Samples.Functional
{
    /// <summary>
    /// Functions for BookTransfer.
    /// </summary>
    public static class TransferFunctions
    {
        public static Regex BicCodeRegex()
            => new Regex("^[A-Z]{6}[A-Z1-9]{5}$");

        /// <summary>
        /// Bic code validation.
        /// </summary>
        public static Validation<BookTransfer> ValidateBic(this BookTransfer cmd, Regex regex)
        {
            if (!regex.IsMatch(cmd.Bic.ToUpper()))
                return Errors.InvalidBic;
            return cmd;
        }

        /// <summary>
        /// Date validation.
        /// </summary>
        public static Validation<BookTransfer> ValidateDate(this BookTransfer cmd, DateTime now)
        {
            if (cmd.Date.Date <= now.Date)
                return Errors.TransferDateIsPast;
            return cmd;
        }
    }
}