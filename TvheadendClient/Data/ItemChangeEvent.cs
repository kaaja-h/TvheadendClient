using System;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Item changed data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemChangeEvent<T>: EventArgs
    where T:IDataItem
    {
        /// <summary>
        /// New event/ updated event (after updating) / deleted event data
        /// </summary>
        public T Item { get; private set; }

        internal ItemChangeEvent(T data )
        {
            Item = data;
        }

    }

}