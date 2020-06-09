using System;
using System.Collections.Generic;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class EpgEvent: DataBase<long>, IEpgEvent
    {

        public long ChannelId { get; private set; }
        public IChannel Channel => this.Data.Channels[ChannelId];

        

        public string Title { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }

        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }

        public long? ContentTypeId { get; private set; }

        public EpgContentType ContentType =>
            (ContentTypeId.HasValue && EpgContentType.DefaultContentTypes.ContainsKey(ContentTypeId.Value))
                ? EpgContentType.DefaultContentTypes[ContentTypeId.Value]
                : null;



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
            ContentTypeId = d.Get("contentType", ContentTypeId);
        }


    }
}