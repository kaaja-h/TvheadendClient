using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class TagHolder : DataHolder<long, Tag, ITag>, ITagStorage
    {
        public TagHolder(TvheadendData data, Client client) : base(data,
            "tagAdd", "tagUpdate", "tagDelete", client)
        {
        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.TagId;
        }
    }
}