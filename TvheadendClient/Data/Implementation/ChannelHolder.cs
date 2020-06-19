using System;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class ChannelHolder:DataHolder<long,Channel, IChannel, ChannelHolder>, IChannelStorage
    {
        public ChannelHolder(TvheadendData data, Client client, ILoggerFactory factory) : base(data, "channelAdd", "channelUpdate", "channelDelete", client, factory)
        {

        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.ChannelId;
        }
    }
}