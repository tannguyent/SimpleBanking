using System;

namespace SimpleBankingApp.Exceptions
{
    public class AccountLogoutException : Exception
    {
        public AccountLogoutException(string message): base(message)
        {

        }
    }
}
