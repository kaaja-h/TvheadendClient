using System;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class TagHolder : DataHolder<long, Tag, ITag, TagHolder>, ITagStorage
    {
        public TagHolder(TvheadendData data, Client client, ILoggerFactory factory) : base(data,
            "tagAdd", "tagUpdate", "tagDelete", client, factory)
        {
        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.TagId;
        }
    }
}