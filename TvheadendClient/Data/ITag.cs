using System;

namespace TvheadendClient.Data
{
    public interface ITag: IDataItem<long>
    {
        IChannel[] Channels { get; }
        string Name { get; }
        long? Index { get; }
        
    }
}