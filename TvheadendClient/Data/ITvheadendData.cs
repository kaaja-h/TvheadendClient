using System;
using System.Collections.Generic;
using TvheadendClient.Data.Dvr;

namespace TvheadendClient.Data
{
    /// <summary>
    /// TvheadendData data storage
    /// </summary>
    public interface ITvheadendData
    {
        /// <summary>
        /// Tags
        /// </summary>
        ITagStorage Tags { get; }

        /// <summary>
        /// Channels
        /// </summary>
        IChannelStorage Channels { get; }

        /// <summary>
        /// Events
        /// </summary>
        IEpgEventStorage Events { get; }

        /// <summary>
        /// Auto recordings
        /// </summary>
        IAutoRecordingStorage AutoRecordings { get; }

        /// <summary>
        /// DvrEntries
        /// </summary>
        IDvrEntryStorage DvrEntries { get; }

        /// <summary>
        /// Time recording entries
        /// </summary>
        ITimeRecordingStorage TimeRecordings { get; }

        /// <summary>
        /// Fired when initial data loading is done
        /// </summary>
        event EventHandler LoadComplete;
        
        /// <summary>
        /// All data loaded - true when initial load is done
        /// </summary>
        bool Ready { get; }

        /// <summary>
        /// Content Type storage
        /// </summary>
        IReadOnlyCollection<string> ContentTypes { get; }

    }
}