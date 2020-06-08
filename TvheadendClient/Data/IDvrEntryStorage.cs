using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IDvrEntryStorage : IItems<IDvrEntry, long>
    {
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByEvent { get; }
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByChannel { get; }

        bool TryDelete(long id);

        bool TryDelete(IDvrEntry item);

        bool TryCancel(long id);

        bool TryCancel(IDvrEntry item);

        bool TryStop(long id);

        bool TryStop(IDvrEntry item);

        bool TryRecordEvent(long eventId, out long dvrEntryId);

        bool TryRecordEvent(IEpgEvent epgEvent, out long dvrEntryId);

        bool TryAddDvrEntry(AddDvrEntryData data, out long dvrEntryId);

        bool TryUpdateDvrEntry(UpdateDvrEntryData data);


    }
}