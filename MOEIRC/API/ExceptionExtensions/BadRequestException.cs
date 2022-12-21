using System;
using System.Collections.Generic;
using System.Text;

namespace MOEIRCNet.API.ExceptionExtensions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
