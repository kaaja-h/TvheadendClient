using System.Collections.Generic;
using System.Linq;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class Channel : DataBase<long>, IChannel
    {

        public IReadOnlyCollection<IEpgEvent> Events =>  (Data.Events.ByChannels.ContainsKey(Id))? Data.Events.ByChannels[Id]:new List<IEpgEvent>();

        public long Number { get; private set; }

        public int? NumberMinor { get; private set; }

        public string Name { get; private set; }

        public string Icon { get; private set; }

        public IEnumerable<ITag> Tags => TagIds.Select(t => Data.Tags[t]);

        public IReadOnlyCollection<long> TagIds {get; private set; }

        public Channel()
        {
            TagIds = System.Array.Empty<long>();
        }

        protected override void UpdateInternal(MessageBase d)
        {
            Name = d.Get("ChannelName", Name);
            Number = d.Get("ChannelNumber", Number);
            NumberMinor = d.Get("ChannelNumberMinor", NumberMinor);
            Icon = d.Get("ChannelIcon", Icon);
            TagIds = d.Get("Tags", TagIds);

        }


    }
}