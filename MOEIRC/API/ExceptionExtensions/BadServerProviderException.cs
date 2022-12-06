using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API.ExceptionExtensions
{
    public class BadServerProviderException : Exception
    {
        public BadServerProviderException()
        {

        }

        public BadServerProviderException(string message) : base(message)
        {
        }

        public BadServerProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
