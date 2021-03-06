﻿using LaYumba.Functional;

namespace Samples.Functional.Transfer
{
    public static class Errors
    {
        public static AccountNotActiveError AccountNotActive
            => new AccountNotActiveError();

        public static CannotActivateClosedAccountError CannotActivateClosedAccount
            => new CannotActivateClosedAccountError();

        public static InsufficientBalanceError InsufficientBalance
            => new InsufficientBalanceError();

        public static InvaliBbeneficiaryError InvalidBeneficiary
            => new InvaliBbeneficiaryError();

        public static InvalidBicError InvalidBic
           => new InvalidBicError();

        public static InvalidIbanError InvalidIban
            => new InvalidIbanError();

        public static InvalidReferenceError InvalidReference
            => new InvalidReferenceError();

        public static InvalidTimestampError InvalidTimestamp
            => new InvalidTimestampError();

        public static NegativeAmountError NegativeAmount
            => new NegativeAmountError();

        public static TransferDateIsPastError TransferDateIsPast
            => new TransferDateIsPastError();

        public static UnexpectedError UnexpectedError
            => new UnexpectedError();

        public static UnknownAccountId UnknownAccountId(string id)
            => new UnknownAccountId(id);
    }

    public sealed class AccountNotActiveError : Error
    {
        public override string Message { get; }
           = "The account is not active; the requested operation cannot be completed.";
    }

    public sealed class CannotActivateClosedAccountError : Error
    {
        public override string Message { get; }
           = "Cannot activate an account that has been closed.";
    }

    public sealed class InsufficientBalanceError : Error
    {
        public override string Message { get; }
           = "Insufficient funds to fulfil the requested operation.";
    }

    public sealed class InvaliBbeneficiaryError : Error
    {
        public override string Message { get; }
            = "The beneficiary must have a name.";
    }

    public sealed class InvalidBicError : Error
    {
        public override string Message { get; }
           = "The beneficiary's BIC/SWIFT code is invalid.";
    }

    public sealed class InvalidIbanError : Error
    {
        public override string Message { get; }
            = "Iban is invalid.";
    }

    public sealed class InvalidReferenceError : Error
    {
        public override string Message { get; }
            = "Reference is invalid.";
    }

    public sealed class InvalidTimestampError : Error
    {
        public override string Message { get; }
            = "Timestamp is invalid. (Has not occured yet.)";
    }

    public sealed class NegativeAmountError : Error
    {
        public override string Message { get; }
           = "The amount is not a positive value.";
    }

    public sealed class TransferDateIsPastError : Error
    {
        public override string Message { get; }
           = "Transfer date cannot be in the past.";
    }

    public sealed class UnexpectedError : Error
    {
        public override string Message { get; }
           = "An unexpected error has occurred.";
    }

    public sealed class UnknownAccountId : Error
    {
        public UnknownAccountId(string id)
        {
            Id = id;
        }

        public override string Message
           => $"No account with id {Id} was found.";

        private string Id { get; }
    }
}