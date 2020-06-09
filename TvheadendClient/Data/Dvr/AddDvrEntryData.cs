using System;
using TvheadendClient.Data.Implementation;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Request data for creating new DVR entry
    /// </summary>
    public class AddDvrEntryData : MessageBase
    {
        /// <summary>
        /// Event Id
        /// </summary>
        public long? EventId => Get<long?>("eventId");

        /// <summary>
        /// ChannelId
        /// </summary>
        public long? ChannelId => Get<long?>("channelId");

        /// <summary>
        /// Start of recording
        /// </summary>
        public DateTime? Start => Get<long?>("start").FromUnixTimestamp();

        /// <summary>
        /// Stop of recording
        /// </summary>
        public DateTime? Stop => Get<long?>("stop").FromUnixTimestamp();

        /// <summary>
        /// Extra time for recording start in minutes
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
        /// Recording retention in days
        /// </summary>
        public long? Retention
        {
            get => Get<long?>("retention");
            set => Set("retention", value);
        }

        /// <summary>
        /// Recording Title
        /// </summary>
        public string Title
        {
            get => Get<string>("title");

        }

        /// <summary>
        /// Recording Subtitle
        /// </summary>
        public string Subtitle
        {
            get => Get<string>("subtitle");
            set => Set("subtitle", value);
        }

        /// <summary>
        /// Recording description
        /// </summary>
        public string Description
        {
            get => Get<string>("Description");
            set => Set("Description", value);
        }

        /// <summary>
        /// Recording enabled
        /// </summary>
        public bool Enabled
        {
            get => Get<long?>("enabled").GetValueOrDefault(0) == 1;
            set => Set("enabled", value ? 1 : 0);
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
        /// Creates new Add recording data 
        /// </summary>
        /// <param name="eventId">Event id</param>
        public AddDvrEntryData(long eventId) : base("addDvrEntry")
        {
            Set("eventId", eventId);
        }


        /// <summary>
        /// Creates new Add recording data
        /// </summary>
        /// <param name="channelId">Id of channel</param>
        /// <param name="start">start of recording</param>
        /// <param name="stop">stop of recording</param>
        /// <param name="title">recording title</param>
        /// <exception cref="ArgumentException">throws when title is not set</exception>
        public AddDvrEntryData(long channelId, DateTime start, DateTime stop, string title) : base("addDvrEntry")
        {
            Set("channelId", channelId);
            Set("start", start.ToUnixTimestamp());
            Set("stop", stop.ToUnixTimestamp());
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("title is needed", nameof(title));
            Set("title", title);

        }
        /// <summary>
        /// Creates new Add recording data
        /// </summary>
        /// <param name="channel">Channel</param>
        /// <param name="start">start of recording</param>
        /// <param name="stop">stop of recording</param>
        /// <param name="title">recording title</param>
        public AddDvrEntryData(IChannel channel, DateTime start, DateTime stop, string title) : this(channel.Id, start, stop, title)
        {

        }


    }
}