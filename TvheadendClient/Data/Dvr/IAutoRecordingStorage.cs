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
    }
}