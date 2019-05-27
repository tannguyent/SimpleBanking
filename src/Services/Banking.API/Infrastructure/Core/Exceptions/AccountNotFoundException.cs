using System;

namespace Banking.API.Infrastructure.Core.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(Guid accountId): base($"can not found account:{accountId}")
        {
        }
    }
}
