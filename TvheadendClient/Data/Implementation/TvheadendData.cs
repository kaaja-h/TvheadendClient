using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TvheadendData : ITvheadendData
    {
        private readonly ILogger<TvheadendData> _logger;

        internal readonly ChannelHolder ChannelHolder;
        internal readonly TagHolder TagHolder;
        internal readonly EpgEventHolder EpgEventHolder;
        internal readonly AutoRecordingDataHolder AutoRecordingDataHolder;
        internal readonly DvrEntryDataHolder DvrEntryDataHolder;
        internal readonly TimeRecordingDataHolder TimeRecordingDataHolder;
        private readonly Client _client;
        internal readonly Dictionary<string, IDvrConfiguration> _dvrConfiguration = new Dictionary<string, IDvrConfiguration>();



        public ITagStorage Tags => TagHolder;
        public IChannelStorage Channels => ChannelHolder;

        public IEpgEventStorage Events => EpgEventHolder;

        public IAutoRecordingStorage AutoRecordings => AutoRecordingDataHolder;

        public IDvrEntryStorage DvrEntries => DvrEntryDataHolder;
        public ITimeRecordingStorage TimeRecordings => TimeRecordingDataHolder;

        public IReadOnlyDictionary<string, IDvrConfiguration> DvrConfigurations => _dvrConfiguration;

        public event EventHandler LoadComplete;




        internal Dictionary<string, Action<MessageBase>> Actions;

        internal TvheadendData(ILogger<TvheadendData> logger, Client client)
        {
            _logger = logger;
            _client = client;
            ChannelHolder = new ChannelHolder(this, _client);
            TagHolder = new TagHolder(this, _client);
            EpgEventHolder = new EpgEventHolder(this, _client);
            AutoRecordingDataHolder = new AutoRecordingDataHolder(this, _client);
            DvrEntryDataHolder = new DvrEntryDataHolder(this, _client);
            TimeRecordingDataHolder = new TimeRecordingDataHolder(this, _client);
            InitActions();
        }


        public bool Ready => _asyncReady && _syncReady;

        private readonly object readyLock = new object();

        private bool _asyncReady = false;
        private bool _syncReady = false;

        private HashSet<string> _contentTypes = new HashSet<string>();

        public IReadOnlyCollection<string> ContentTypes => _contentTypes;


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
            AddActions(TagHolder.GetActions(), Actions);
            AddActions(ChannelHolder.GetActions(), Actions);
            AddActions(EpgEventHolder.GetActions(), Actions);
            AddActions(AutoRecordingDataHolder.GetActions(), Actions);
            AddActions(DvrEntryDataHolder.GetActions(), Actions);
            AddActions(TimeRecordingDataHolder.GetActions(), Actions);
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