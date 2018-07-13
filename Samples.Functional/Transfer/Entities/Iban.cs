using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct Iban
    {
        private Iban(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Iban> Of(string value)
            => IsValid(value)
                ? Valid(new Iban(value))
                : Invalid(Errors.InvalidIban);

        private static bool IsValid(string value) // TODO: Make a better validation, see https://en.wikipedia.org/wiki/International_Bank_Account_Number
            => !string.IsNullOrWhiteSpace(value);
    }
}