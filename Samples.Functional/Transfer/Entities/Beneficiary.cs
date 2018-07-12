using LaYumba.Functional;

namespace Samples.Functional.Transfer.Entities
{
    public struct Beneficiary
    {
        private Beneficiary(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Beneficiary> Of(string value)
            => IsValid(value)
                ? F.Valid(new Beneficiary(value))
                : F.Invalid(Errors.InvalidBeneficiary);

        private static bool IsValid(string value)
            => !string.IsNullOrWhiteSpace(value);
    }
}