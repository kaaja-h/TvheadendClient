using System.Collections.Generic;

namespace TvheadendClient.Data.Implementation
{
    internal class EventComparer : IComparer<IEpgEvent>
    {
        public int Compare(IEpgEvent x, IEpgEvent y)
        {
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x.Start < y.Start)
                return -1;
            if (y.Start < x.Start)
                return 1;
            return 0;
        }
    }
}