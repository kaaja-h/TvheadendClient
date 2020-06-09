using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class AutoRecordingDataHolder : DataHolder<string, AutoRecordingEntry, IAutoRecordingEntry>, IAutoRecordingStorage
    {
        public AutoRecordingDataHolder(TvheadendData data, Client client) : base(data, "autorecEntryAdd", "autorecEntryUpdate", "autorecEntryDelete", client)
        {
        }

        protected override string ExtractId(MessageBase msg)
        {
            dynamic d = msg;
            return d.Id;
        }
    }
}