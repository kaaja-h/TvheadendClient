using System;

namespace TvheadendClient.Exceptions
{
    /// <summary>
    /// Exception throwed when error serializing and deserializing message
    /// </summary>
    public class HtspMessageException : HtspException
    {
        internal HtspMessageException(string message) : base(message)
        {
        }

        internal HtspMessageException()
        {

        }

        internal HtspMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}