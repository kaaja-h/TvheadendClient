using System;
using System.Collections.Generic;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class EpgEvent: DataBase<long>, IEpgEvent
    {

        public long ChannelId { get; private set; }
        public IChannel Channel => this.Data.Channels.Items[ChannelId];

        

        public string Title { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }

        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }

        public long? ContentType { get; private set; }

        public IReadOnlyCollection<IDvrEntry> DvrEntries => Data.DvrEntries.ByEvent.ContainsKey(Id)?Data.DvrEntries.ByEvent[Id]:Array.Empty<IDvrEntry>();

        protected override void UpdateInternal(MessageBase d)
        {
            ChannelId = d.Get("channelId", ChannelId);
            Title = d.Get("title", Title);
            Description = d.Get("description", Description);
            Summary = d.Get("summary", Summary);
            var start = d.Get<long?>("start");
            if (start.HasValue)
                Start = start.Value.FromUnixTimestamp();
            var stop = d.Get<long?>("stop");
            if (stop.HasValue)
                Stop = stop.Value.FromUnixTimestamp();
            ContentType = d.Get("contentType", ContentType);
        }


    }
}