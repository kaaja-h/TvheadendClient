using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IEpgEvent: IDataItem<long>
    {
        IChannel Channel { get; }
        long ChannelId { get;  }
        string Title { get; }
        string Summary { get; }
        string Description { get; }
        DateTime Start { get; }
        DateTime Stop { get; }
        long? ContentType { get; }

        IReadOnlyCollection<IDvrEntry> DvrEntries { get; }
    }
}