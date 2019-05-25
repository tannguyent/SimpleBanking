using System;

namespace SimpleBankingApp.Exceptions
{
    public class AccountLoginException: Exception
    {
        public AccountLoginException(string message): base(message)
        {

        }
    }
}
