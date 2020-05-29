using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        private  readonly ConcurrentDictionary<long, EpgEvent> _epgEvents = new ConcurrentDictionary<long, EpgEvent>();

        public ITagStorage Tags => _tagHolder;
        public IChannelStorage Channels => _channelHolder;

        public IEpgEventStorage Events => _epgEventHolder;

        public IAutoRecordStorage AutoRecords => _autoRecordDataHolder;

        public IDvrEntryStorage DvrEntries => _dvrEntryDataHolder;

        public event EventHandler LoadComplete;




        internal Dictionary<string, Action<MessageBase>> Actions;

        internal TvheadendData(ILogger<TvheadendData> logger)
        {
            _logger = logger;
            _channelHolder = new ChannelHolder(this);
            _tagHolder = new TagHolder(this);
            _epgEventHolder = new EpgEventHolder(this);
            
            
            _autoRecordDataHolder = new AutoRecordDataHolder(this);
            _dvrEntryDataHolder= new DvrEntryDataHolder(this);
            InitActions();
            Ready = false;
            
        }

        
        public bool Ready{get; private set;}

        internal HashSet<string> contentTypes= new HashSet<string>();

        public IReadOnlyCollection<string> ContentTypes => contentTypes;

        
        private void InitialSyncCompleted(MessageBase msg)
        {
            Ready = true;
            _logger.LogDebug("initial sync complete");
            LoadComplete?.Invoke(this, new EventArgs());
        }

        private void AddActions(IEnumerable<(string, Action<MessageBase>)> data, Dictionary<string, Action<MessageBase>>  dict)
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
            AddActions(_dvrEntryDataHolder.GetActions(),Actions);
        }


        internal void ReceiveMessage(MessageBase msg)
        {
            if (Actions.TryGetValue(msg.Method, out var action))
                action(msg);
        }

    }
}