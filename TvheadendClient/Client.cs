using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using TvheadendClient.Data;
using TvheadendClient.Data.Implementation;
using TvheadendClient.Messages;
using TvheadendClient.MessageSending;

namespace TvheadendClient
{
    public sealed class Client : IDisposable
    {
        private readonly HtspClientSendReceiver _client;

        private readonly HtspMessageSender _sender;

        private byte[] _digest;

        private readonly ClientOptions _options;

        public bool Connected{get; private set;}


        public Client(ClientOptions options, ILoggerFactory loggerFactory)
        {
            if (options==null || string.IsNullOrEmpty(options.Host))
                throw new ArgumentException("invalid options",nameof(options));
            if (loggerFactory == null)
                throw new ArgumentException("invalid logger factory", nameof(loggerFactory));
            _options = options;
            _client = new HtspClientSendReceiver(options.Host, options.Port, options.Ipv6, loggerFactory);
            _sender = new HtspMessageSender(_client, loggerFactory);

            _data = new TvheadendData(loggerFactory.CreateLogger<TvheadendData>(),this);
        }

        private readonly TvheadendData _data;
        public ITvheadendData Data => _data;

        public void Dispose()
        {
            _client?.Dispose();
        }


        public void Connect()
        {
            _client.Connect(_sender.Receive);
            dynamic helloResponse = Hello();
            PrepareDigest(helloResponse.Challenge);

            EnableAsyncMetadata();
            Connected = true;
        }


        public void Disconnect()
        {
            _client.Disconnect();
        }

        private void PrepareDigest(byte[] challenge)
        {
            
            
            var bytes = Encoding.ASCII.GetBytes(_options.Password);
            var data = new byte[bytes.Length + challenge.Length];
            Array.Copy(bytes, data, bytes.Length);
            Array.Copy(challenge, 0, data, bytes.Length, challenge.Length);

            SHA1 sha = new SHA1CryptoServiceProvider();
            _digest = sha.ComputeHash(data);
        }

        internal MessageBase Send(MessageBase message)
        {
            if (_digest != null)
            {
                message.Digest = _digest;
                message.UserName = _options.UserName;
            }

            var res = _sender.Send(message);
            if (res.Noaccess == 1)
                throw new Exception();
            return res;
        }

        /*
        public GetDvrConfigsResponse GetDvrConfigs(GetDvrConfigsRequest request)
        {
            return Send<GetDvrConfigsRequest, GetDvrConfigsResponse>(request);
        }
        *
        public AddDvrEntryResponse Record(AddDvrEntryRequest request)
        {
            return Send<AddDvrEntryRequest, AddDvrEntryResponse>(request);
        }
        /*
        public DeleteDvrEntryResponse DeleteDvrEntry(DeleteDvrEntryRequest req){
            return Send<DeleteDvrEntryRequest, DeleteDvrEntryResponse>(req);
        }
        */




        private MessageBase Hello()
        {
            dynamic request = new MessageBase("hello");
            request.clientname = "HtspClient.net";
            request.htspversion = 23;

            return Send(request);
        }


        private void EnableAsyncMetadata()
        {
            _sender.AddMessageSubscription(_data.Actions.Keys, _data.ReceiveMessage);
            dynamic request = new MessageBase("enableAsyncMetadata");
            request.epg = 1;
            request.language = _options.Culture.Name;


            Send(request);
            
            return;
        }
    }
}