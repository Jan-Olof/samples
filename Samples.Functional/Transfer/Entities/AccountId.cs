//using LaYumba.Functional;
//using System;

//namespace Samples.Functional.Transfer.Entities
//{
//    public struct AccountId // TODO: Finish this.
//    {
//        private AccountId(string value)
//            => Value = Guid.Parse(value);

//        public Guid Value { get; }

//        public static Validation<AccountId> Of(string value)
//            => IsValid(value)
//                ? F.Valid(new AccountId(value))
//                : F.Invalid(Errors.UnknownAccountId);

//        private static bool IsValid(string value)
//            => !string.IsNullOrWhiteSpace(value);
//    }
//}