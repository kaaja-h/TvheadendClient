using System;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TimeRecording: DataBase<string>, ITimeRecording
    {
        public string Title { get; private set; }
        public bool Enabled { get; private set; }
        public string Name { get; private set; }
        public long ChannelId { get; private set; }
        public IChannel Channel => (Data.Channels.ContainsKey(ChannelId)) ? Data.Channels[ChannelId] : null;
        public DaysOfWeek DaysOfWeek { get; private set; }
        public long Start { get; private set; }
        public long Stop { get; private set; }
        public long Retention { get; private set; }
        public string Directory { get; private set; }
        public string ConfigurationId { get; private set; }

        public long? Priority { get; private set; }

        protected override void UpdateInternal(MessageBase data)
        {
            Title = data.Get<string>("title",Title);
            var en = data.Get<long?>("enabled");
            if (en.HasValue)
                Enabled = en.GetValueOrDefault(0) == 1;
            Name = data.Get<string>("name", Name);
            ChannelId = data.Get<long>("channel", ChannelId);
            var dw = data.Get<long?>("daysOfWeek");
            if (dw.HasValue)
            {
                DaysOfWeek = (DaysOfWeek) dw.Value;
            }

            Stop = data.Get("stop", Stop);
            Start = data.Get("start", Start);
            Retention = data.Get("retention", Retention);
            Directory = data.Get("directory", Directory);
            ConfigurationId = data.Get("configName", ConfigurationId);
            Priority = data.Get("priority", Priority);
        }
    }
}