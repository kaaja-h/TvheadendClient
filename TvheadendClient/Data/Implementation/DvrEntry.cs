﻿using System;
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

        public string TimerecId { get; private set; }

        public ITimeRecording TimeRecording  => (TimerecId==null)?null:Data.TimeRecordings[TimerecId];


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
            TimerecId = d.Get("timerecid", TimerecId);


        }
    }
}