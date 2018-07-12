using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct Amount
    {
        private Amount(decimal value)
            => Value = value;

        public decimal Value { get; }

        public static Validation<Amount> Of(decimal value)
             => IsValid(value)
                ? Valid(new Amount(value))
                : Invalid(Errors.NegativeAmount);

        private static bool IsValid(decimal value)
            => value > 0;
    }
}