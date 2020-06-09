using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Channel
    /// </summary>
    public interface IChannel: IDataItem<long>
    {
        /// <summary>
        /// Events
        /// </summary>
        IReadOnlyCollection<IEpgEvent> Events { get; }
        /// <summary>
        /// Channel number
        /// </summary>
        long Number { get; }

        /// <summary>
        /// Channel number minor
        /// </summary>
        int? NumberMinor { get; }

        /// <summary>
        /// channel name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// channel Icon
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// Channel Tags
        /// </summary>
        IEnumerable<ITag> Tags { get; }

        /// <summary>
        /// Channel tag Ids
        /// </summary>

        IReadOnlyCollection<long> TagIds { get; }
        
    }
}