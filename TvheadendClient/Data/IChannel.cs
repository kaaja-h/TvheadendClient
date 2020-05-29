using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IChannel: IDataItem<long>
    {
        IReadOnlyCollection<IEpgEvent> Events { get; }
        long Number { get; }
        int? NumberMinor { get; }
        string Name { get; }
        string Icon { get; }
        IEnumerable<ITag> Tags { get; }

        IReadOnlyCollection<long> TagIds { get; }
        
    }
}