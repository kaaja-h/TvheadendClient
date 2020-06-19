using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class EpgEventHolder:DataHolder<long, EpgEvent, IEpgEvent, EpgEventHolder>, IEpgEventStorage
    {

        public IReadOnlyDictionary<long, IReadOnlyCollection<IEpgEvent>> ByChannels => _byChannels;

        private readonly ConcurrentDictionary<long, IReadOnlyCollection<IEpgEvent>> _byChannels = new ConcurrentDictionary<long, IReadOnlyCollection<IEpgEvent>>();

        internal readonly Dictionary<long,long> NextEvents = new Dictionary<long, long>();
        internal readonly Dictionary<long, long> PreviousEvents = new Dictionary<long, long>();



        public EpgEventHolder(TvheadendData data, Client client, ILoggerFactory factory) : base(data, "eventAdd", "eventUpdate", "eventDelete", client, factory)
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
            
            if (data.NextEventId.HasValue)
            {
                NextEvents[data.Id] = data.NextEventId.Value;
                PreviousEvents[data.NextEventId.Value] = data.Id;
                if (this.data.ContainsKey(data.NextEventId.Value))
                {
                    var next = this.data[data.NextEventId.Value];
                    if (next.PreviousEventId != data.Id)
                    {
                        next.PreviousEventId = data.Id;
                        UpdatedExternal(next.Id);
                    }
                }
            }

            if (PreviousEvents.ContainsKey(data.Id))
            {
                data.PreviousEventId = PreviousEvents[data.Id];
            }
            
            
                
            base.OnCreate(data);
        }

        protected override void OnUpdate(EpgEvent data)
        {
            if (NextEvents.ContainsKey(data.Id) && NextEvents[data.Id]!= data.NextEventId.GetValueOrDefault(0))
            {
                PreviousEvents.Remove(NextEvents[data.Id]);
                if (data.NextEventId.HasValue)
                {
                    var oldnext = this.data[NextEvents[data.Id]];
                    oldnext.PreviousEventId = null;
                    UpdatedExternal(oldnext.Id);
                    var next = this.data[data.NextEventId.Value];
                    next.PreviousEventId = data.Id;
                    UpdatedExternal(next.Id);
                    NextEvents[data.Id] = data.NextEventId.Value;
                    PreviousEvents[data.NextEventId.Value] = data.Id;
                }
                else
                {
                    NextEvents.Remove(data.Id);
                }
            }
            else
            {
                if (data.NextEventId.HasValue)
                {
                    NextEvents[data.Id] = data.NextEventId.Value;
                    PreviousEvents[data.NextEventId.Value] = data.Id;
                }
            }
            base.OnUpdate(data);
        }

        protected override void OnDelete(EpgEvent data)
        {
            (_byChannels[data.ChannelId] as SortedSet<IEpgEvent>).Remove(data);
            if (NextEvents.ContainsKey(data.Id))
            {
                var oldnext = this.data[NextEvents[data.Id]];
                oldnext.PreviousEventId = null;
                UpdatedExternal(oldnext.Id);
                PreviousEvents.Remove(NextEvents[data.Id]);
                NextEvents.Remove(data.Id);
            }


            base.OnDelete(data);
        }
    }
}