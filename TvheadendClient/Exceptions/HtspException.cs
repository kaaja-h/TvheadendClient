using System;

namespace TvheadendClient.Exceptions
{
    public class HtspException : Exception
    {
        public HtspException(string message) : base(message)
        {
        }

        public HtspException()
        {

        }

        public HtspException(string message, Exception innerException) : base(message,innerException)
        {
        }
    }
}