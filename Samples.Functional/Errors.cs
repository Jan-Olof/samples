using LaYumba.Functional;
using System;

namespace Samples.Functional
{
    public static class Errors
    {
        public static AccountNotActiveError AccountNotActive
            => new AccountNotActiveError();

        public static CannotActivateClosedAccountError CannotActivateClosedAccount
            => new CannotActivateClosedAccountError();

        public static InsufficientBalanceError InsufficientBalance
            => new InsufficientBalanceError();

        public static InvalidBicError InvalidBic
            => new InvalidBicError();

        public static NegativeAmountError NegativeAmount
            => new NegativeAmountError();

        public static TransferDateIsPastError TransferDateIsPast
            => new TransferDateIsPastError();

        public static UnexpectedError UnexpectedError
            => new UnexpectedError();

        public static Error UnknownAccountId(Guid id)
            => new UnknownAccountId(id);
    }

    public sealed class AccountNotActiveError : Error
    {
        public override string Message { get; }
           = "The account is not active; the requested operation cannot be completed";
    }

    public sealed class CannotActivateClosedAccountError : Error
    {
        public override string Message { get; }
           = "Cannot activate an account that has been closed";
    }

    public sealed class InsufficientBalanceError : Error
    {
        public override string Message { get; }
           = "Insufficient funds to fulfil the requested operation";
    }

    public sealed class InvalidBicError : Error
    {
        public override string Message { get; }
           = "The beneficiary's BIC/SWIFT code is invalid";
    }

    public sealed class NegativeAmountError : Error
    {
        public override string Message { get; }
           = "The amount is a negative value.";
    }

    public sealed class TransferDateIsPastError : Error
    {
        public override string Message { get; }
           = "Transfer date cannot be in the past";
    }

    public sealed class UnexpectedError : Error
    {
        public override string Message { get; }
           = "An unexpected error has occurred";
    }

    public sealed class UnknownAccountId : Error
    {
        public UnknownAccountId(Guid id)
        {
            Id = id;
        }

        public override string Message
           => $"No account with id {Id} was found";

        private Guid Id { get; }
    }
}