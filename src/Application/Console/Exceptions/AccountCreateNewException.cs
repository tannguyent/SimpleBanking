using System;

namespace SimpleBankingApp.Exceptions
{
    public class AccountCreateNewException : Exception
    {
        public AccountCreateNewException(string message): base(message)
        {
        }
    }
}
