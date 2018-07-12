using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using static LaYumba.Functional.F;

namespace Samples.Functional.Transfer.Entities
{
    public struct AccountId
    {
        private AccountId(string value)
            => Value = Guid.Parse(value);

        public Guid Value { get; }

        public static Validation<AccountId> Of(string value)
            => IsValid(value)
                ? Valid(new AccountId(value))
                : Invalid(Errors.UnknownAccountId(value));

        private static bool IsValid(string value)
            => value.IsGuid();
    }
}