using LaYumba.Functional;

namespace Samples.Functional.Transfer.Entities
{
    public struct Amount
    {
        private Amount(decimal value)
            => Value = value;

        public decimal Value { get; }

        public static Validation<Amount> Of(decimal value)
             => IsValid(value)
                ? F.Valid(new Amount(value))
                : F.Invalid(Errors.NegativeAmount);

        private static bool IsValid(decimal value)
            => value > 0;
    }
}