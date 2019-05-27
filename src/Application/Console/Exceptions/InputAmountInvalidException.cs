using System;

namespace SimpleBankingApp.Exceptions
{
    public class InputAmountInvalidException : Exception
    {
        public InputAmountInvalidException(decimal amount) : base("amount must greater than 0")
        {
        }
    }
}
