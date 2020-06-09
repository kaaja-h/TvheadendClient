using System;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;


namespace TvheadendClient.Data.Implementation
{
    internal class AutoRecordingEntry:DataBase<string>, IAutoRecordingEntry
    {
        public bool Enabled { get; private set; }
        public string Title { get; private set; }

        public long? ChannelId { get; private set; }

        public IChannel Channel => (ChannelId.HasValue)?Data.Channels[ChannelId.Value]:null;

        public string Name {get; private set;}

        public bool Fulltext {get; private set;}

        

        protected override void UpdateInternal(MessageBase d)
        {

            var enabled = d.Get<long?>("enabled");
            if (enabled.HasValue)
            {
                Enabled = (enabled == 1);
            }

            Title = d.Get("title", Title);
            ChannelId = d.Get("Channel", ChannelId);
            Name = d.Get("name", Name);
            var fulltext = d.Get<long?>("fulltext");
            if (fulltext.HasValue)
                Fulltext = (fulltext == 1);
        }
    }
}