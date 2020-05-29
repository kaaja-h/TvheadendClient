using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IDvrEntryStorage : IItems<IDvrEntry, long>
    {
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByEvent { get; }
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByChannel { get; }
    }
}