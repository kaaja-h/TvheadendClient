using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TimerecEntryDataHolder: DataHolder<string, TimerecEntry, ITimerecEntry>, ITimerecEntryStorage
    {
        public TimerecEntryDataHolder(TvheadendData data, Client client) : base(data, "timerecEntryAdd", "timerecEntryUpdate", "timerecEntryDelete", client)
        {
        }

        protected override string ExtractId(MessageBase msg)
        {
            return msg.Get<string>("id");
        }
    }
}