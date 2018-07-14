using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct Reference
    {
        private Reference(string value)
            => Value = value;

        public string Value { get; }

        public static Validation<Reference> Of(string value)
            => IsValid(value)
                ? Valid(new Reference(value))
                : Invalid(Errors.InvalidReference);

        private static bool IsValid(string value)
            => value != null;
    }
}