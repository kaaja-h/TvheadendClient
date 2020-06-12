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


        /// <summary>
        /// Forced directory name
        /// </summary>
        string Directory { get; }

        /// <summary>
        /// Minimal duration in seconds (0 = Any).
        /// </summary>
        long? MinimalDuration { get; }

        /// <summary>
        /// Maximal duration in seconds(0 = Any).
        /// </summary>
        long? MaximalDuration { get; }

        /// <summary>
        /// Days of week 
        /// </summary>
        DaysOfWeek DaysOfWeek { get; }

        /// <summary>
        /// Priority
        /// </summary>
        long? Priority { get; }

        /// <summary>
        /// Minutes from midnight (up to 24*60) for the start of the time window (including) 
        /// </summary>
        long? Start { get; }

        /// <summary>
        /// Minutes from midnight (up to 24*60) for the end of the time window (including, cross-noon allowed)
        /// </summary>
        long? StartWindow { get; }

        /// <summary>
        /// Extra time before start in minutes
        /// </summary>
        long? StartExtra { get; }

        /// <summary>
        /// Extra time after stop
        /// </summary>
        long? StopExtra { get; }

        /// <summary>
        /// DuplicityDetection
        /// </summary>
        DuplicityDetection DuplicityDetection { get; }

        /// <summary>
        /// Retention time (in days). 
        /// </summary>
        long? Retention { get;  }

        /// <summary>
        /// Minutes from midnight (up to 24*60).
        /// </summary>
        long? ApproximateTime { get;  }
    }
}