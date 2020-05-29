using System;

namespace TvheadendClient.Exceptions
{
    public class HtspMessageException : HtspException
    {
        public HtspMessageException(string message) : base(message)
        {
        }

        public HtspMessageException()
        {

        }

        public HtspMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}