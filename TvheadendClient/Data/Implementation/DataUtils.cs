using System;

namespace TvheadendClient.Data.Implementation
{
    internal static class DataUtils
    {
        private static readonly long ticks = Init();

        private static long Init()
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime.Ticks;
        }

        public static DateTime FromUnixTimestamp(this long date)
        {
            
            return new DateTime(ticks + (date * 1000L * TimeSpan.TicksPerMillisecond));
            
        }
    }
}