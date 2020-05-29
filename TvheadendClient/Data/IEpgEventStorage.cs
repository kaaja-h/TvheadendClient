using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IEpgEventStorage: IItems<IEpgEvent, long>
    {
        IReadOnlyDictionary<long, IReadOnlyCollection<IEpgEvent>> ByChannels { get; }
    }
}