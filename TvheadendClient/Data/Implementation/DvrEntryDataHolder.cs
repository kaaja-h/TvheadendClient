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
        public bool TryDeleteItem(long id)
        {
            dynamic message = new MessageBase("deleteDvrEntry");
            message.id = id;
            MessageBase res = client.Send(message);
            return res.Get<long?>("success").GetValueOrDefault(0) == 1;

        }

        public bool TryDeleteItem(IDvrEntry item)
        {
            return TryDeleteItem(item.Id);
        }

        public bool TryRecordEvent(long eventId, out long dvrEntryId)
        {
            return TryRecord(new AddDvrEntryData(eventId), out dvrEntryId);
        }

        public bool TryRecordEvent(IEpgEvent epgEvent, out long dvrEntryId)
        {
            return TryRecord(new AddDvrEntryData(epgEvent.Id), out dvrEntryId);
        }

        public bool TryRecord(AddDvrEntryData data, out long dvrEntryId)
        {
            MessageBase res = client.Send(data);
            dvrEntryId = res.Get<long?>("id").GetValueOrDefault(0);
            return res.Get<long?>("success").GetValueOrDefault(0) == 1;
        }


        public DvrEntryDataHolder(TvheadendData data, Client client) : base(data, "dvrEntryAdd", "dvrEntryUpdate", "dvrEntryDelete", client)
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