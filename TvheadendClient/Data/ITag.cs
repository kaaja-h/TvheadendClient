using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Tag
    /// </summary>
    public interface ITag: IDataItem<long>
    {
        /// <summary>
        /// Channels
        /// </summary>
        IEnumerable<IChannel> Channels { get; }

        /// <summary>
        /// Tag name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Tag index
        /// </summary>
        long? Index { get; }
        
    }
}