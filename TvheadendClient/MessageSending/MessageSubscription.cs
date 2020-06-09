using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.MessageSending
{
    internal class MessageSubscription
    {
        private readonly Action<MessageBase> _action;
        private readonly ILogger<MessageSubscription> _logger;
        private readonly BlockingCollection<MessageBase> _messages = new BlockingCollection<MessageBase>();

        private readonly CancellationTokenSource _src = new CancellationTokenSource();
        private readonly HashSet<string> _types;


        internal MessageSubscription(IEnumerable<string> types, Action<MessageBase> action,
            ILogger<MessageSubscription> logger
        )
        {
            _action = action;
            _logger = logger;
            _types = new HashSet<string>(types);
            Task.Run(Process);
        }

        internal void AddMessage(MessageBase msg)
        {
            if (_types.Contains(msg.Method))
                _messages.Add(msg);
        }

        private void Process()
        {
            try
            {
                while (!_src.IsCancellationRequested)
                {
                    var item = _messages.Take(_src.Token);
                    try
                    {
                        _action(item);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, "error runing action");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        internal void Stop()
        {
            _src.Cancel();
        }
    }
}