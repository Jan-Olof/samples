﻿//using LaYumba.Functional;
//using System;
//using System.Text.RegularExpressions;
//using static LaYumba.Functional.F;

//namespace Samples.Functional
//{
//    /// <summary>
//    /// Functions for BookTransfer.
//    /// </summary>
//    public static class TransferFunctions
//    {
//        /// <summary>
//        /// Bic code validation.
//        /// </summary>
//        public static Validation<BookTransfer> ValidateBic(this BookTransfer transfer, Regex regex)
//            => Some(transfer)
//                .Where(t => regex.IsMatch(t.Bic.ToUpper()))
//                .Match<Validation<BookTransfer>>(() => Errors.InvalidBic, t => t);

//        /// <summary>
//        /// Date validation.
//        /// </summary>
//        public static Validation<BookTransfer> ValidateDate(this BookTransfer transfer, DateTime now)
//            => Some(transfer)
//                .Where(t => t.Date.Date > now.Date)
//                .Match<Validation<BookTransfer>>(() => Errors.TransferDateIsPast, t => t);
//    }
//}