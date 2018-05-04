using LaYumba.Functional;
using System;

namespace Samples.Functional
{
    /// <summary>
    /// Functions for BookTransfer.
    /// </summary>
    public static class TransferFunctions
    {
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