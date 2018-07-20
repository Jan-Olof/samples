using LaYumba.Functional;
using System;
using System.Collections.Generic;

namespace Samples.Functional.Helpers
{
    public static class ValidationHelper // TODO: Test!
    {
        /// <summary>
        /// Get all errors.
        /// </summary>
        public static IEnumerable<Error> GetErrors<T>(this Validation<T> validation)
            => validation.Match(e => e, d => new List<Error>());

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know the object is valid.)
        /// </summary>
        public static T GetObject<T>(this Validation<T> validation)
            => validation.Match(e => throw new InvalidOperationException("The object is invalid."), d => d);
    }
}