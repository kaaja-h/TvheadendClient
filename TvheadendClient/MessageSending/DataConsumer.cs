using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.MessageSending
{
    internal class DataConsumer
    {
        private readonly ILogger<DataConsumer> _logger;
        private Action<int, byte[]> _messageReceivedCallback;


        private readonly BlockingCollection<(byte[] data, int length)> _data =
            new BlockingCollection<(byte[] data, int length)>(5);

        public DataConsumer(ILogger<DataConsumer> logger)
        {
            _logger = logger;
        }


        public void Add(byte[] data, int length)
        {
            this._data.Add((data, length));
        }

        public void StartConsuming(Action<int, byte[]> messageReceivedCallback, CancellationToken t)
        {
            _messageReceivedCallback = messageReceivedCallback;

            Task.Run(() => Process(t), t);
            _logger.LogDebug("Started message consuming");
        }


        private void Process(CancellationToken t)
        {
            var watingMessageLength = true;
            var data = new byte[4];
            var readedDataCount = 0;
            (byte[] data, int length) currentData = (Array.Empty<byte>(), 0);
            var currentDataOffset = 0;

            while (!t.IsCancellationRequested)
            {
                while (readedDataCount < data.Length)
                {
                    if (currentDataOffset >= currentData.length)
                    {
                        currentData = this._data.Take(t);
                        currentDataOffset = 0;
                    }

                    var currentLength = currentData.length - currentDataOffset > data.Length - readedDataCount
                        ? data.Length - readedDataCount
                        : currentData.length - currentDataOffset;
                    Array.Copy(currentData.data, currentDataOffset, data, readedDataCount, currentLength);
                    readedDataCount += currentLength;
                    currentDataOffset += currentLength;
                }

                if (watingMessageLength)
                {
                    var messageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(data,0));
                    data = new byte[messageLength];
                }
                else
                {
                    //push message out

                    var tmp = new byte[data.Length];
                    Array.Copy(data, tmp, data.Length);
                    _messageReceivedCallback(tmp.Length, tmp);
                    data = new byte[4];
                }

                readedDataCount = 0;
                watingMessageLength = !watingMessageLength;
            }
        }
    }
}