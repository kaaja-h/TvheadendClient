using System;

namespace TvheadendClient.Data
{
    public class ItemChangeEvent<T>: EventArgs
    where T:IDataItem
    {
        public T Item { get; private set; }

        internal ItemChangeEvent(T data )
        {
            Item = data;
        }

    }

}