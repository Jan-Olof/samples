using LaYumba.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Samples.Functional.Transfer
{
    /// <summary>
    /// Functions for BookTransfer.
    /// </summary>
    public static class TransferFunctions
    {
        public static IEnumerable<T> AddMany<T>(this IEnumerable<T> e, IEnumerable<T> n) // TODO: Move
        {
            var list = e.ToList();
            list.AddRange(n);
            return list;
        }

        public static IEnumerable<Error> GetErrors<T>(this Validation<T> validation)
        {
            return validation.Match(e => e, d => new List<Error>()); // TODO: Test!
        }

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException.
        /// </summary>
        public static T GetObject<T>(this Validation<T> validation)
        {
            return validation.Match(e => throw new InvalidOperationException("The object is invalid."), d => d); // TODO: Test!
        }

        /// <summary>
        /// Bic code validation.
        /// </summary>
        public static Validation<BookTransferDto> ValidateBic(this BookTransferDto transfer, Regex regex)
            => F.Some(transfer)
                .Where(t => regex.IsMatch(t.Bic.ToUpper()))
                .Match<Validation<BookTransferDto>>(() => Errors.InvalidBic, t => t);

        /// <summary>
        /// Date validation.
        /// </summary>
        public static Validation<BookTransferDto> ValidateDate(this BookTransferDto transfer, DateTime now)
            => F.Some(transfer)
                .Where(t => t.Date.Date > now.Date)
                .Match<Validation<BookTransferDto>>(() => Errors.TransferDateIsPast, t => t);
    }
}