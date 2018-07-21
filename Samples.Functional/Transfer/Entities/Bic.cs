using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct Bic
    {
        private Bic(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Bic> Of(string value)
            => IsValid(value)
                ? Valid(new Bic(value))
                : Invalid(Errors.InvalidBic);

        private static bool IsValid(string value)
            => Settings.BicCodeRegex().IsMatch(value?.ToUpper() ?? "");
    }
}