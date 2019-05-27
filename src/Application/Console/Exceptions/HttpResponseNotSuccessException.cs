using System;

namespace SimpleBankingApp.Exceptions
{
    public class HttpResponseNotSuccessException : Exception
    {
        public HttpResponseNotSuccessException(string message) : base(message)
        {
        }
    }
}
