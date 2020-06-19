using System.IO;
using Microsoft.Extensions.Logging;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    class TimeRecordingDataHolder: DataHolder<string, TimeRecording, ITimeRecording, TimeRecordingDataHolder>, ITimeRecordingStorage
    {
        public TimeRecordingDataHolder(TvheadendData data, Client client, ILoggerFactory factory) : base(data, "timerecEntryAdd", "timerecEntryUpdate", "timerecEntryDelete", client, factory)
        {
        }

        protected override string ExtractId(MessageBase msg)
        {
            return msg.Get<string>("id");
        }

        public bool TryAddTimeRecording(AddTimeRecordingEntryData data, out string id)
        {
            dynamic res = this.client.Send(data);
            id = null;
            if (res.success != 1)
            {
                string error = res.error;
                long seq = res.seq;
                logger.LogError($"error calling addTimerecEntry seq {seq} error {error}");
                return false;
            }

            id = res.id;
            return true;

        }

        public bool TryDeleteTimeRecording(ITimeRecording item) => TryDeleteTimeRecording(item.Id);

        public bool TryDeleteTimeRecording(string itemId)
        {
            dynamic data = new MessageBase("deleteTimerecEntry");
            data.id = itemId;
            dynamic res = this.client.Send(data);
            if (res.success != 1)
            {
                string error = res.error;
                long seq = res.seq;
                logger.LogError($"error calling deleteTimerecEntry seq {seq} error {error}");
                return false;
            }

            return true;
        }
    }
}