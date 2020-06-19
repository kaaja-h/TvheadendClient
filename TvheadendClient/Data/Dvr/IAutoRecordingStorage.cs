namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Storage for automatic recordings
    /// </summary>
    public interface IAutoRecordingStorage : IItems<IAutoRecordingEntry, string>
    {
        /// <summary>
        /// Add autorecording entry
        /// </summary>
        /// <param name="data">Autorecording data</param>
        /// <param name="entryId">new autorecording id</param>
        /// <returns></returns>
        bool TryAddAutoRecording(AddAutoRecordingEntryData data, out long entryId);

        /// <summary>
        /// try delete autoRecording
        /// </summary>
        /// <param name="entry">entry</param>
        /// <returns>success</returns>
        bool TryDeleteAutoRecording(IAutoRecordingEntry entry);

        /// <summary>
        /// try delete autoRecording
        /// </summary>
        /// <param name="entryId">entry id</param>
        /// <returns>success</returns>
        bool TryDeleteAutoRecording(string entryId);
    }
}