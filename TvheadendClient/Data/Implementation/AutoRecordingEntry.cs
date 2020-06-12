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
        public string Directory { get; private set; }
        public long? MinimalDuration { get; private set; }
        public long? MaximalDuration { get; private set; }
        public DaysOfWeek DaysOfWeek { get; private set; }
        public long? Priority { get; private set; }
        public long? Start { get; private set; }
        public long? StartWindow { get; private set; }
        public long? StartExtra { get; private set; }
        public long? StopExtra { get; private set; }
        public DuplicityDetection DuplicityDetection { get; private set; }

        public long? Retention { get; private set; }

        public long? ApproximateTime { get; private set; }

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
            Directory = d.Get("directory", Directory);
            MinimalDuration = d.Get("minDuration", MinimalDuration);
            MaximalDuration = d.Get("maxDuration", MaximalDuration);
            DaysOfWeek = (DaysOfWeek) d.Get<long?>("daysOfWeek",(long) DaysOfWeek);
            Priority = d.Get("priority", Priority);
            Start = d.Get("start", Start);
            StartWindow = d.Get("startWindow", StartWindow);
            StartExtra = d.Get("startExtra", StartExtra);
            StopExtra = d.Get("stopExtra", StopExtra);
            DuplicityDetection = (DuplicityDetection)d.Get<long?>("dupDetect", (long)DuplicityDetection);
            Retention = d.Get("retentions", Retention);
            ApproximateTime = d.Get("retentions", ApproximateTime);
        }
    }
}