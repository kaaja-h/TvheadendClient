using System.Collections.Generic;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Epg event storage
    /// </summary>
    public interface IEpgEventStorage: IItems<IEpgEvent, long>
    {
        /// <summary>
        /// Events indexed by channels
        /// </summary>
        IReadOnlyDictionary<long, IReadOnlyCollection<IEpgEvent>> ByChannels { get; }
    }
}