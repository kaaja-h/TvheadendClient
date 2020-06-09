namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Automatic recording based on epg data
    /// </summary>
    public interface IAutoRecordingEntry: IDataItem<string>
    {
        /// <summary>
        /// Enabled
        /// </summary>
        bool Enabled { get;  }
        /// <summary>
        /// Title for recording
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Autorecording name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Channel id
        /// </summary>
        long? ChannelId{get;}

        /// <summary>
        /// Channel
        /// </summary>
        IChannel Channel{get;}

        /// <summary>
        /// Fulltext enabled
        /// </summary>

        bool Fulltext { get; }


    }
}