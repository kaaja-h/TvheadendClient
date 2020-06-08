using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface ITvheadendData
    {
        ITagStorage Tags { get; }
        IChannelStorage Channels { get; }
        IEpgEventStorage Events { get; }
        IAutoRecordStorage AutoRecords { get; }
        IDvrEntryStorage DvrEntries { get; }

        ITimerecEntryStorage TimerecEntries { get; }

        event EventHandler LoadComplete;
        
        bool Ready { get; }
        IReadOnlyCollection<string> ContentTypes { get; }

    }
}