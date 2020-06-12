using System;
using System.Runtime.CompilerServices;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class DvrEntry:DataBase<long>, IDvrEntry
    {

        public long ChannelId { get; private set; }
        public IChannel Channel => Data.Channels[ChannelId];

        public long? EventId { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }

        public IEpgEvent Event => (EventId.HasValue && Data.Events.ContainsKey(EventId.Value))?Data.Events[EventId.Value]:null;

        public string AutorecordId { get; private set; }
        public IAutoRecordingEntry AutoRecordingEntry => (AutorecordId==null)?null:Data.AutoRecordings[AutorecordId];

        public string Description{get; private set;}

        public string Title { get;  private set;}

        public string Subtitle { get;  private set;}

        public string Summary { get;  private set;}

        public string State{get; private set;}

        public bool Enabled{get;private set;}

        public string Comment{get;private set;}

        public string TimeRecordingId { get; private set; }

        public ITimeRecording TimeRecording  => (TimeRecordingId==null)?null:Data.TimeRecordings[TimeRecordingId];



        public long? StartExtra { get; private set; }


        public long? StopExtra { get; private set; }
        
        public long? Retention { get; private set; }

        public long? Priority { get; private set; }

        public long? ContentTypeId { get; private set; }

        public EpgContentType ContentType =>
            (ContentTypeId.HasValue && EpgContentType.DefaultContentTypes.ContainsKey(ContentTypeId.Value))
                ? EpgContentType.DefaultContentTypes[ContentTypeId.Value]
                : null;

        public string Image { get; private set; }

        public long? Datasize { get; private set; }



        protected override void UpdateInternal(MessageBase d)
        {
            ChannelId = d.Get("channel", ChannelId);
            EventId = d.Get("eventId", EventId);
            AutorecordId = d.Get("autorecId", AutorecordId);
            var start = d.Get<long?>("start");
            if (start.HasValue)
                Start = start.Value.FromUnixTimestamp();
            var stop = d.Get<long?>("stop");
            if (stop.HasValue)
                Stop = stop.Value.FromUnixTimestamp();
            Description = d.Get("description", Description);
            Title = d.Get("title", Title);
            Subtitle = d.Get("subtitle", Subtitle);
            Summary = d.Get("summary", Summary);
            var enabled = d.Get<long?>("enabled");
            if (enabled.HasValue)
                Enabled = enabled.Value == 1;
            Comment = d.Get("comment", Comment);
            State = d.Get("state", State);
            TimeRecordingId = d.Get("timerecid", TimeRecordingId);
            StartExtra = d.Get("startExtra", StartExtra);
            StopExtra = d.Get("stopExtra", StopExtra);
            Retention = d.Get("retention", Retention);
            Priority = d.Get("priority", Priority);
            ContentTypeId = d.Get("contentType", ContentTypeId);
            Image = d.Get("image", Image);
            Datasize = d.Get("datasize", Datasize);
        }
    }
}