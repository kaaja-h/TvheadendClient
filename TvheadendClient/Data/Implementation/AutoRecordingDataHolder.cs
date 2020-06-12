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

        public bool TryAddAutoRecording(AddAutoRecordingEntryData data, out long entryId)
        {
            var res = client.Send(data);
            entryId = res.Get("id",0);
            return res.Get<long?>("success") == 1;
        }
    }
}