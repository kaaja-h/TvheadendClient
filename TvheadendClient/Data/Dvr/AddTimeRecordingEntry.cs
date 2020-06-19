using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Request data for creating new Time recording
    /// </summary>
    public class AddTimeRecordingEntryData: MessageBase
    {
        /// <summary>
        ///  Enabled flag 
        /// </summary>
        public bool? Enabled
        {
            get => Get<long?>("enabled")?.Equals(1);
            set => Set("enabled", (value.HasValue) ? ((value.Value) ? 1 : 0) : (long?) null);
        }

        /// <summary>
        /// Title for the recordings.
        /// </summary>
        public string Title => Get<string>("title");

        /// <summary>
        /// Forced output directory name 
        /// </summary>
        public string Directory
        {
            get => Get<string>("directory");
            set => Set("directory", value);
        }

        /// <summary>
        /// Name for this timerec entry
        /// </summary>
        public string Name
        {
            get => Get<string>("name");
            set => Set("name", value);
        }

        /// <summary>
        /// DVR Configuration Name / UUID.
        /// </summary>
        public string ConfigurationName
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
        /// Days of week
        /// </summary>
        public DayOfWeek DaysOfWeek
        {
            get => (DayOfWeek)Get<long>("daysOfWeek");
            set => Set("daysOfWeek", (long)value);
        }

        /// <summary>
        /// Priority 
        /// </summary>
        public long? Priority
        {
            get => Get<long?>("priority");
            set => Set("priority", value);
        }

        /// <summary>
        /// Minutes from midnight (up to 24*60) for the start of the time window 
        /// </summary>
        public long? Start
        {
            get => Get<long?>("start");
            set => Set("start", value);
        }

        /// <summary>
        /// Minutes from midnight (up to 24*60) for the end of the time window (including, cross-noon allowed)
        /// </summary>
        public long? Stop
        {
            get => Get<long?>("stop");
            set => Set("stop", value);
        }

        /// <summary>
        /// Retention in days. 
        /// </summary>
        public long? Retention
        {
            get => Get<long?>("retention");
            set => Set("retention", value);
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
        /// Creates new instance with title
        /// </summary>
        /// <param name="title"></param>
        public AddTimeRecordingEntryData(string title) : base("addTimerecEntry")
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title shout be not null", nameof(title));
            Set("title",title);
        }
    }
}