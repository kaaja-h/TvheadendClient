using System;
using TvheadendClient.Exceptions;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Data for adding autorecording entry
    /// </summary>
    public class AddAutoRecordingEntryData:MessageBase
    {
        /// <summary>
        /// Title for the recordings.
        /// </summary>
        public string Title => Get<string>("title");

        /// <summary>
        /// Enabled flag 
        /// </summary>
        public bool? Enabled
        {
            get => Get<long?>("enabled")?.Equals(1);
            set { if (value.HasValue) Set("enabled", value.Value ? 0 : 1); }
        }

        /// <summary>
        /// Full text flag
        /// </summary>
        public bool? Fulltext
        {
            get => Get<long?>("fulltext")?.Equals(1);
            set { if (value.HasValue) Set("fulltext", value.Value ? 0 : 1); }
        }

        /// <summary>
        /// Forced directory name - missing or empty = auto 
        /// </summary>
        public string Directory
        {
            get => Get<string>("directory");
            set => Set("directory",value);
        }

        /// <summary>
        /// Name of this autorec entry 
        /// </summary>
        public string Name
        {
            get => Get<string>("name");
            set => Set("name", value);
        }

        /// <summary>
        /// DVR Configuration Name / UUID
        /// </summary>
        public string ConfigurationId
        {
            get => Get<string>("configName");
            set => Set("configName", value);
        }

        /// <summary>
        /// Channel ID
        /// </summary>
        public long? ChannelId
        {
            get => Get<long?>("channelId");
            set => Set("channelId", value);
        }

        /// <summary>
        /// Minimal duration in seconds (0 = Any)
        /// </summary>
        public long? MinimalDuration
        {
            get => Get<long?>("minDuration");
            set => Set("minDuration", value);
        }

        /// <summary>
        /// Maximal duration in seconds (0 = Any)
        /// </summary>
        public long? MaximalDuration
        {
            get => Get<long?>("maxDuration");
            set => Set("maxDuration", value);
        }

        /// <summary>
        /// Days of week 
        /// </summary>
        public DayOfWeek DaysOfWeek
        {
            get => (DayOfWeek) Get<long>("daysOfWeek");
            set => Set("daysOfWeek", (long) value);
        }

        /// <summary>
        /// Priority (0 = Important, 1 = High, 2 = Normal, 3 = Low, 4 = Unimportant, 5 = Not set).
        /// </summary>
        public long? Priority
        {
            get => Get<long?>("priority");
            set => Set("priority", value);
        }


        /// <summary>
        /// Minutes from midnight (up to 24*60) for the start of the time window (including)
        /// </summary>
        public long? Start
        {
            get => Get<long?>("start");
            set => Set("start", value);
        }

        /// <summary>
        /// Minutes from modnight (up to 24*60) for the end of the time window (including, cross-noon allowed)
        /// </summary>
        public long? StartWindow
        {
            get => Get<long?>("startWindow");
            set => Set("startWindow", value);
        }

        /// <summary>
        /// Extra start minutes (pre-time).
        /// </summary>
        public long? StartExtra
        {
            get => Get<long?>("startExtra");
            set => Set("startExtra", value);
        }


        /// <summary>
        /// Extra stop for recording stop in minutes
        /// </summary>
        public long? StopExtra
        {
            get => Get<long?>("stopExtra");
            set => Set("stopExtra", value);
        }

        /// <summary>
        /// Duplicity Detection
        /// </summary>
        public DuplicityDetection DuplicityDetection
        {
            get => (DuplicityDetection)Get<long>("dupDetect");
            set => Set("dupDetect", (long)value);
        }

        /// <summary>
        /// User Comment
        /// </summary>
        public string Comment
        {
            get => Get<string>("comment");
            set => Set("comment", value);
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="title">Recording title</param>
        /// <exception cref="ArgumentException">when title is invalid</exception>
        public AddAutoRecordingEntryData(string title) : base("addAutorecEntry")
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("title not provided",nameof(title));
            Set("title",title);
        }
    }
}