using System;

namespace TvheadendClient.Exceptions
{
    /// <summary>
    /// Exception raised when noacces is returned from server
    /// </summary>
    public class NoAccessException : HtspException
    {
        internal NoAccessException() : base("Access disabled to tvheadend")
        {
        }

        internal NoAccessException(string message) : base(message)
        {

        }

        internal NoAccessException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}