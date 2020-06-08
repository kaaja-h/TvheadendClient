using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TvheadendData : ITvheadendData
    {
        private readonly ILogger<TvheadendData> _logger;

        private readonly ChannelHolder _channelHolder;
        private readonly TagHolder _tagHolder;
        private readonly EpgEventHolder _epgEventHolder;
        private readonly AutoRecordDataHolder _autoRecordDataHolder;
        private readonly DvrEntryDataHolder _dvrEntryDataHolder;

        private readonly TimerecEntryDataHolder _timerecEntryDataHolder;
        private readonly Client _client;
        private readonly Dictionary<string, IDvrConfiguration> _dvrConfiguration = new Dictionary<string, IDvrConfiguration>();

        private readonly ConcurrentDictionary<long, EpgEvent> _epgEvents = new ConcurrentDictionary<long, EpgEvent>();

        public ITagStorage Tags => _tagHolder;
        public IChannelStorage Channels => _channelHolder;

        public IEpgEventStorage Events => _epgEventHolder;

        public IAutoRecordStorage AutoRecords => _autoRecordDataHolder;

        public IDvrEntryStorage DvrEntries => _dvrEntryDataHolder;
        public ITimerecEntryStorage TimerecEntries => _timerecEntryDataHolder;

        public IReadOnlyDictionary<string, IDvrConfiguration> DvrConfigurations => _dvrConfiguration;

        public event EventHandler LoadComplete;




        internal Dictionary<string, Action<MessageBase>> Actions;

        internal TvheadendData(ILogger<TvheadendData> logger, Client client)
        {
            _logger = logger;
            _client = client;
            _channelHolder = new ChannelHolder(this, _client);
            _tagHolder = new TagHolder(this, _client);
            _epgEventHolder = new EpgEventHolder(this, _client);
            _autoRecordDataHolder = new AutoRecordDataHolder(this, _client);
            _dvrEntryDataHolder = new DvrEntryDataHolder(this, _client);
            _timerecEntryDataHolder = new TimerecEntryDataHolder(this, _client);
            InitActions();
        }


        public bool Ready => _asyncReady && _syncReady;

        private object readyLock = new object();

        private bool _asyncReady = false;
        private bool _syncReady = false;

        internal HashSet<string> contentTypes = new HashSet<string>();

        public IReadOnlyCollection<string> ContentTypes => contentTypes;


        private void InitialSyncCompleted(MessageBase msg)
        {
            lock (readyLock)
            {
                _asyncReady = true;
                _logger.LogDebug("initial sync complete");
                if (Ready) LoadComplete?.Invoke(this, new EventArgs());
            }
        }

        private void AddActions(IEnumerable<(string, Action<MessageBase>)> data, Dictionary<string, Action<MessageBase>> dict)
        {
            foreach (var d in data)
            {
                dict[d.Item1] = d.Item2;
            }
        }

        private void InitActions()
        {
            Actions = new Dictionary<string, Action<MessageBase>>
            {

                {"initialSyncCompleted", a=> InitialSyncCompleted(a)},
            };
            AddActions(_tagHolder.GetActions(), Actions);
            AddActions(_channelHolder.GetActions(), Actions);
            AddActions(_epgEventHolder.GetActions(), Actions);
            AddActions(_autoRecordDataHolder.GetActions(), Actions);
            AddActions(_dvrEntryDataHolder.GetActions(), Actions);
            AddActions(_timerecEntryDataHolder.GetActions(), Actions);
        }

        internal void Init()
        {
            Task.Run(InitSync);
        }

        private void InitSync()
        {


            var msg = new MessageBase("getDvrConfigs");
            dynamic res = _client.Send(msg);
            dynamic[] items = res.dvrconfigs;
            foreach (var item in items)
            {
                var d = new DvrConfiguration()
                {
                    Id = item.uuid,
                    Name = item.name,
                    Comment = item.comment
                };
                _dvrConfiguration[d.Id] = d;
            }

            lock (readyLock)
            {
                _syncReady = true;
                if (Ready) LoadComplete?.Invoke(this, new EventArgs());
            }


        }

        internal void ReceiveMessage(MessageBase msg)
        {
            if (Actions.TryGetValue(msg.Method, out var action))
                action(msg);
        }

    }
}