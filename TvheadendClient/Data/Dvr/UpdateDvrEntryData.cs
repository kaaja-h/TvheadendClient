using System;
using TvheadendClient.Data.Implementation;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Data for updating Dvr Entry. When is property null, property is not changed
    /// </summary>
    public class UpdateDvrEntryData : MessageBase
    {
        /// <summary>
        /// Dvr entry Id
        /// </summary>
        public long Id => Get<long>("id");

        /// <summary>
        /// Channel Id
        /// </summary>
        public long? ChannelId
        {
            get => Get<long?>("channelId");
            set => Set("channelId", value);
        }

        /// <summary>
        /// Recording start
        /// </summary>
        public DateTime? Start
        {
            get => Get<long?>("startExtra").FromUnixTimestamp();
            set => Set("startExtra", value.ToUnixTimestamp());
        }

        /// <summary>
        /// Recording stop
        /// </summary>
        public DateTime? Stop
        {
            get => Get<long?>("stop").FromUnixTimestamp();
            set => Set("stop", value.ToUnixTimestamp());
        }

        /// <summary>
        /// Extra time before recording start
        /// </summary>
        public long? StartExtra
        {
            get => Get<long?>("startExtra");
            set => Set("startExtra", value);
        }

        /// <summary>
        /// Extra time after recording stop
        /// </summary>
        public long? StopExtra
        {
            get => Get<long?>("stopExtra");
            set => Set("stopExtra", value);
        }

        /// <summary>
        /// Recording title
        /// </summary>
        public string Title
        {
            get => Get<string>("title");

        }

        /// <summary>
        /// Recording subtitle
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
        /// Enabled
        /// </summary>
        public bool Enabled
        {
            get => Get<long?>("enabled").GetValueOrDefault(0) == 1;
            set => Set("enabled", value ? 1 : 0);
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
        /// Constructor
        /// </summary>
        /// <param name="id">Id of updated recording</param>
        public UpdateDvrEntryData(long id)
        {
            Set("id",id);
        }
    }
}