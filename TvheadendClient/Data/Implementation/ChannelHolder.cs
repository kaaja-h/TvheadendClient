using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class ChannelHolder:DataHolder<long,Channel, IChannel>, IChannelStorage
    {
        public ChannelHolder(TvheadendData data, Client client) : base(data, "channelAdd", "channelUpdate", "channelDelete", client)
        {

        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.ChannelId;
        }
    }
}