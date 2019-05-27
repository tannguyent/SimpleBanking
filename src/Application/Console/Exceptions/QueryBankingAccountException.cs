using System;

namespace SimpleBankingApp.Exceptions
{
    public class QueryBankingAccountException : Exception
    {
        public QueryBankingAccountException(string message) : base(message)
        {
        }
    }
}
