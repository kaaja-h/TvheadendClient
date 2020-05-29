using System;

namespace TvheadendClient.Exceptions
{
    public class NoAccessException : HtspException
    {
        public NoAccessException() : base("Access disabled to tvheadend")
        {
        }

        public NoAccessException(string message) : base(message)
        {

        }

        public NoAccessException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}