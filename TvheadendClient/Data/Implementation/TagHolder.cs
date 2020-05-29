using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class TagHolder : DataHolder<long, Tag, ITag>, ITagStorage
    {
        public TagHolder(TvheadendData data) : base(data,
            "tagAdd", "tagUpdate", "tagDelete")
        {
        }

        protected override long ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.TagId;
        }
    }
}