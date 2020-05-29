using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class DvrEntryDataHolder : DataHolder<long, DvrEntry, IDvrEntry>, IDvrEntryStorage
    {


        private readonly ConcurrentDictionary<long, IReadOnlyCollection<IDvrEntry>> _byEvent = new ConcurrentDictionary<long, IReadOnlyCollection<IDvrEntry>>();
        public IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByEvent=>_byEvent;

        private readonly ConcurrentDictionary<long, IReadOnlyCollection<IDvrEntry>> _byChannel = new ConcurrentDictionary<long, IReadOnlyCollection<IDvrEntry>>();
        public IReadOnlyDictionary<long, IReadOnlyCollection<IDvrEntry>> ByChannel => _byChannel;




        public DvrEntryDataHolder(TvheadendData data) : base(data, "dvrEntryAdd", "dvrEntryUpdate", "dvrEntryDelete")
        {
        }


        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.Id;
        }

        protected override void OnCreate(DvrEntry data)
        {
            base.OnCreate(data);
            if (data.EventId.HasValue)
            {
                _byEvent.AddOrUpdate(data.EventId.Value,
                    a=> new List<IDvrEntry>(new[] { data}) ,
                    (a, b) => { (b as List<IDvrEntry>).Add(data);
                        return b;
                    }
                );
                base.TvData.Events.UpdatedExternal(data.EventId.Value);
            }

            _byChannel.AddOrUpdate(
                data.ChannelId,
                a => new List<IDvrEntry>(new[] {data}),
                (a, b) =>
                {
                    (b as List<IDvrEntry>).Add(data);
                    return b;
                }
            );
        }

        protected override void OnDelete(DvrEntry data)
        {
            base.OnDelete(data);
            if (data.EventId.HasValue)
            {
                _byEvent.AddOrUpdate(data.EventId.Value,
                    a => new List<IDvrEntry>(),
                    (a, b) => {
                        (b as List<IDvrEntry>).Remove(data);
                        return b;
                    }
                );
                base.TvData.Events.UpdatedExternal(data.EventId.Value);
            }
            _byChannel.AddOrUpdate(
                data.ChannelId,
                a => new List<IDvrEntry>(),
                (a, b) =>
                {
                    (b as List<IDvrEntry>).Remove(data);
                    return b;
                }
            );
        }
    }
}