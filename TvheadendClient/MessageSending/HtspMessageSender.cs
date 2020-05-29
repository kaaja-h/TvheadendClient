using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;
using TvheadendClient.Serialization;

namespace TvheadendClient.MessageSending
{
    internal class HtspMessageSender
    {
        private readonly HtspClientSendReceiver _sender;

        private readonly ILogger<HtspMessageSender> _logger;
        private readonly ILoggerFactory _loggerFactory;

        private readonly Serializer _serializer;

        private readonly ConcurrentDictionary<MessageSubscription, MessageSubscription> _subscriptions =
            new ConcurrentDictionary<MessageSubscription, MessageSubscription>();

        private long _messageId = 1;

        private readonly ConcurrentDictionary<long, Sync> _sync = new ConcurrentDictionary<long, Sync>();


        public HtspMessageSender(HtspClientSendReceiver sender, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _sender = sender;
            _logger = loggerFactory.CreateLogger<HtspMessageSender>();
            _serializer = new Serializer(loggerFactory);
        }


        public void Receive(int messageLength, byte[] data)
        {
            var message = _serializer.Deserialize(messageLength, data);
            if (message == null)
                return;

            foreach (var item in _subscriptions.Keys)
                item.AddMessage(message);
            if (!message.Seq.HasValue)
                return;


            var seq = message.Seq.Value;
            if (_sync.ContainsKey(seq))
            {
                _sync[seq].Response = message;
                _sync[seq].Ev.Set();
                _sync.TryRemove(seq, out _);
            }
        }


        public MessageBase Send(MessageBase message)
        {
            var i = Interlocked.Increment(ref _messageId);
            message.Seq = i;
            using (var ms = new MemoryStream())
            {
                _serializer.Serialize(message, ms);
                var s = new Sync()                ;
                _sync[i] = s;
                _sender.Send(ms.ToArray());

                s.Ev.WaitOne();
                return s.Response;
            }
        }

        public MessageSubscription AddMessageSubscription(IEnumerable<string> types, Action<MessageBase> action)
        {
            var sub = new MessageSubscription(types, action, _loggerFactory.CreateLogger<MessageSubscription>());
            _subscriptions.GetOrAdd(sub, t => t);
            return sub;
        }

        public void Unsubscribe(MessageSubscription subs)
        {
            if (_subscriptions.TryRemove(subs, out var s)) s.Stop();
        }

        private class Sync
        {
            public readonly ManualResetEvent Ev = new ManualResetEvent(false);
            public MessageBase Response;
        }
    }
}