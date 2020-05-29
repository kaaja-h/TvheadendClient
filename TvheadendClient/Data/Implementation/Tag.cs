using System.Linq;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class Tag : DataBase<long>, ITag
    {
        private long[] _members;
        public IChannel[] Channels => _members?.Select(d => Data.Channels.Items[d]).ToArray();

        public string Name { get; private set; }
        public long? Index { get; private set; }

        protected override void UpdateInternal(MessageBase d)
        {
            Name = d.Get("tagName", Name);
            Index = d.Get("tagIndex", Index);
            _members = d.Get("members", _members);
        }


    }
}