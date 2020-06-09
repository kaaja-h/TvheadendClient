using System;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Enum for days of week Multiple options can be specified using |
    /// </summary>
    [Flags]
    public enum DaysOfWeek
    {
        /// <summary>
        /// Monday
        /// </summary>
        Monday = 1,

        /// <summary>
        /// Tuesday
        /// </summary>
        Tuesday = 2,

        /// <summary>
        /// Wednesday
        /// </summary>
        Wednesday = 4,

        /// <summary>
        /// Thursday
        /// </summary>
        Thursday = 8,

        /// <summary>
        /// Friday
        /// </summary>
        Friday = 16,

        /// <summary>
        /// Saturday
        /// </summary>
        Saturday = 32,

        /// <summary>
        /// Sunday
        /// </summary>
        Sunday = 64,

        /// <summary>
        /// Everyday
        /// </summary>
        Everyday = Monday | Tuesday | Wednesday| Thursday | Friday | Saturday | Sunday
    }
}