using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class AutoRecordDataHolder : DataHolder<string, AutoRecord, IAutoRecord>, IAutoRecordStorage
    {
        public AutoRecordDataHolder(TvheadendData data, Client client) : base(data, "autorecEntryAdd", "autorecEntryUpdate", "autorecEntryDelete", client)
        {
        }

        protected override string ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.Id;
        }
    }
}