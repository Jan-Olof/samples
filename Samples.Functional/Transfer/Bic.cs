using LaYumba.Functional;
using System.Text.RegularExpressions;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct Bic
    {
        private static readonly Regex BicRegex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");

        private Bic(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Bic> Of(string value)
            => IsValid(value)
                ? Valid(new Bic(value))
                : Invalid(Errors.InvalidBic);

        private static bool IsValid(string value)
            => BicRegex.IsMatch(value.ToUpper());
    }
}