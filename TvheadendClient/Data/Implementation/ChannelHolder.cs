using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class ChannelHolder:DataHolder<long,Channel, IChannel>, IChannelStorage
    {
        public ChannelHolder(TvheadendData data) : base(data, "channelAdd", "channelUpdate", "channelDelete")
        {

        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.ChannelId;
        }
    }
}