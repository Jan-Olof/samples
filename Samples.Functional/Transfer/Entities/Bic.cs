using LaYumba.Functional;

namespace Samples.Functional.Transfer.Entities
{
    public struct Bic
    {
        private Bic(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Bic> Of(string value)
            => IsValid(value)
                ? F.Valid(new Bic(value))
                : F.Invalid(Errors.InvalidBic);

        private static bool IsValid(string value)
            => Settings.BicCodeRegex().IsMatch(value.ToUpper());
    }
}