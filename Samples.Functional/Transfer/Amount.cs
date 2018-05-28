using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer
{
    public struct Amount
    {
        public Amount(decimal value)
            => Value = value;

        private decimal Value { get; }

        public static Option<Amount> Of(decimal value)
             => IsValid(value)
                ? Some(new Amount(value))
                : None;

        private static bool IsValid(decimal value)
            => value > 0;
    }
}