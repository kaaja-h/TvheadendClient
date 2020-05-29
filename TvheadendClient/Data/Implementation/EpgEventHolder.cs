using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class EpgEventHolder:DataHolder<long, EpgEvent, IEpgEvent>, IEpgEventStorage
    {

        public IReadOnlyDictionary<long, IReadOnlyCollection<IEpgEvent>> ByChannels => _byChannels;

        private readonly ConcurrentDictionary<long, IReadOnlyCollection<IEpgEvent>> _byChannels = new ConcurrentDictionary<long, IReadOnlyCollection<IEpgEvent>>();


        public EpgEventHolder(TvheadendData data) : base(data, "eventAdd", "eventUpdate", "eventDelete")
        {

        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.EventId;
        }

        protected override void OnCreate(EpgEvent data)
        {
            _byChannels.AddOrUpdate(data.ChannelId,
                d => new SortedSet<IEpgEvent>(new[] {data}, new EventComparer()),
                (a, b) =>
                {
                    (b as SortedSet<IEpgEvent>).Add(data);
                    return b;
                });
            base.OnCreate(data);
        }

        protected override void OnDelete(EpgEvent data)
        {
            (_byChannels[data.ChannelId] as SortedSet<IEpgEvent>).Remove(data);
            base.OnDelete(data);
        }
    }
}