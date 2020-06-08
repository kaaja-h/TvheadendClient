using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IDvrEntryStorage : IItems<IDvrEntry, long>
    {
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByEvent { get; }
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByChannel { get; }

        bool TryDeleteItem(long id);

        bool TryDeleteItem(IDvrEntry item);

        bool TryRecordEvent(long eventId, out long dvrEntryId);

        bool TryRecordEvent(IEpgEvent epgEvent, out long dvrEntryId);
    }
}