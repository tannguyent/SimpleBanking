using System;

namespace Banking.API.Infrastructure.Core.Exceptions
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(Guid accountId) : base($"transaction invalid for accountid = {accountId}")
        {
        }
    }
}
