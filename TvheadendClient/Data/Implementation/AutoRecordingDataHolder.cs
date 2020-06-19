using Microsoft.Extensions.Logging;
using TvheadendClient.Data.Dvr;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal class AutoRecordingDataHolder : DataHolder<string, AutoRecordingEntry, IAutoRecordingEntry, AutoRecordingDataHolder>, IAutoRecordingStorage
    {
        public AutoRecordingDataHolder(TvheadendData data, Client client, ILoggerFactory factory) : base(data, "autorecEntryAdd", "autorecEntryUpdate", "autorecEntryDelete", client, factory)
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
            var result =  res.Get<long?>("success") == 1;
            if (!result)
            {
                var seq = res.Get<long?>("seq");
                var error = res.Get<string>("error");
                logger.LogError($"error calling addAutorecEntry seq {seq} error {error}");
            }

            return result;


        }

        public bool TryDeleteAutoRecording(IAutoRecordingEntry entry) => TryDeleteAutoRecording(entry.Id);

        public bool TryDeleteAutoRecording(string entryId)
        {
            dynamic request = new MessageBase("deleteAutorecEntry");
            request.id = entryId;
            var res = client.Send(request);
            var result = res.Get<long?>("success") == 1;
            if (!result)
            {
                var seq = res.Get<long?>("seq");
                var error = res.Get<string>("error");
                logger.LogError($"error calling deleteAutorecEntry seq {seq} error {error}");
            }

            return result;
        }
    }
}