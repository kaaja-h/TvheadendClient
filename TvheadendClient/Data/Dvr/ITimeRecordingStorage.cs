namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Time recording storage
    /// </summary>
    public interface ITimeRecordingStorage : IItems<ITimeRecording, string>
    {
        /// <summary>
        /// Try add time recording
        /// </summary>
        /// <param name="data">time recording data</param>
        /// <param name="id">id of created item</param>
        /// <returns></returns>
        bool TryAddTimeRecording(AddTimeRecordingEntryData data, out string id);

        /// <summary>
        /// Try delete time recording
        /// </summary>
        /// <param name="item">item to delete</param>
        /// <returns>success</returns>
        bool TryDeleteTimeRecording(ITimeRecording item);

        /// <summary>
        /// Try delete time recording
        /// </summary>
        /// <param name="itemId">item id to delete</param>
        /// <returns>success</returns>
        bool TryDeleteTimeRecording(string  itemId);

    }
}