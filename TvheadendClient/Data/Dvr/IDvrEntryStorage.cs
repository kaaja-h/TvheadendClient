using System.Collections.Generic;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Dvr entry storage. 
    /// </summary>
    public interface IDvrEntryStorage : IItems<IDvrEntry, long>
    {
        /// <summary>
        /// Dvr events indexed by event id
        /// </summary>
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByEvent { get; }

        /// <summary>
        /// Dvr events indexed by channel id
        /// </summary>
        IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByChannel { get; }

        /// <summary>
        /// Try delete dvr entry by id
        /// </summary>
        /// <param name="id">dvr entry id</param>
        /// <returns>true when success</returns>
        bool TryDelete(long id);

        /// <summary>
        /// Try delete dvr entry by id
        /// </summary>
        /// <param name="item">dvr entry from deleting</param>
        /// <returns>true when success</returns>
        bool TryDelete(IDvrEntry item);

        /// <summary>
        /// Try cancel dvr entry by id (do not delete)
        /// </summary>
        /// <param name="id">dvr entry id</param>
        /// <returns>true when success</returns>
        bool TryCancel(long id);

        /// <summary>
        /// Try cancel dvr entry by id (do not delete)
        /// </summary>
        /// <param name="item">dvr entry from deleting</param>
        /// <returns>true when success</returns>
        bool TryCancel(IDvrEntry item);

        /// <summary>
        /// Try stop recording (only when recording in progress)
        /// </summary>
        /// <param name="id">dvr entry id</param>
        /// <returns>true when success</returns>
        bool TryStop(long id);
        /// <summary>
        /// Try stop recording (only when recording in progress)
        /// </summary>
        /// <param name="item">dvr entry from deleting</param>
        /// <returns>true when success</returns>
        bool TryStop(IDvrEntry item);

        /// <summary>
        /// Try add event recording 
        /// </summary>
        /// <param name="eventId">event id</param>
        /// <param name="dvrEntryId">id of created dvr entry</param>
        /// <returns>true when success</returns>
        bool TryRecordEvent(long eventId, out long dvrEntryId);

        /// <summary>
        /// Try add event recording 
        /// </summary>
        /// <param name="epgEvent">Epg event</param>
        /// <param name="dvrEntryId">id of created dvr entry</param>
        /// <returns>true when success</returns>
        bool TryRecordEvent(IEpgEvent epgEvent, out long dvrEntryId);

        /// <summary>
        /// Add new Dvr entry
        /// </summary>
        /// <param name="data">data for new dvr entry</param>
        /// <param name="dvrEntryId">id of created dvr entry</param>
        /// <returns>true when success</returns>
        bool TryAddDvrEntry(AddDvrEntryData data, out long dvrEntryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">data for updating dvr entry</param>
        /// <returns>true when success</returns>
        bool TryUpdateDvrEntry(UpdateDvrEntryData data);


    }
}