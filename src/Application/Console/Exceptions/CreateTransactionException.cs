using System;

namespace SimpleBankingApp.Exceptions
{
    public class CreateTransactionException : Exception
    {
        public CreateTransactionException(string message) : base(message)
        {
        }
    }
}
