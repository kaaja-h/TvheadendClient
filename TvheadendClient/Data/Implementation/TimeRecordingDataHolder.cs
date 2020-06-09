using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TimeRecordingDataHolder: DataHolder<string, TimeRecording, ITimeRecording>, ITimeRecordingStorage
    {
        public TimeRecordingDataHolder(TvheadendData data, Client client) : base(data, "timerecEntryAdd", "timerecEntryUpdate", "timerecEntryDelete", client)
        {
        }

        protected override string ExtractId(MessageBase msg)
        {
            return msg.Get<string>("id");
        }
    }
}