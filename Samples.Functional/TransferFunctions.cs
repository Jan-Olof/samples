using LaYumba.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static LaYumba.Functional.F;

namespace Samples.Functional
{
    /// <summary>
    /// Functions for BookTransfer.
    /// </summary>
    public static class TransferFunctions
    {
        public static IEnumerable<T> AddMany<T>(this IEnumerable<T> e, IEnumerable<T> n)
        {
            var list = e.ToList();
            list.AddRange(n);
            return list;
        }

        public static T GetValidObject<T>(this Validation<T> validation)
        {
            return validation.Match(e => throw new InvalidOperationException("The object is invalid."), d => d); // TODO: Test!
        }

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

        //public static Validation<BookTransfer> ValidateDate(this BookTransfer transfer, Validation<Amount> amount)
        //{
        //}
    }
}