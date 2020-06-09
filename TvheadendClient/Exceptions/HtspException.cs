using System;

namespace TvheadendClient.Exceptions
{
    /// <summary>
    /// Exception raised when communicating with server
    /// </summary>
    public class HtspException : Exception
    {
        internal HtspException(string message) : base(message)
        {
        }

        internal HtspException()
        {

        }

        internal HtspException(string message, Exception innerException) : base(message,innerException)
        {
        }
    }
}