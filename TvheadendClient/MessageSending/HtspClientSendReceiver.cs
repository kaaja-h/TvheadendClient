using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Extensions.Logging;
using TvheadendClient.Exceptions;

namespace TvheadendClient.MessageSending
{
    internal class HtspClientSendReceiver : IDisposable
    {
        private Socket _client;
        private bool _connected;
        private readonly IPAddress _ipAddress;

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<HtspClientSendReceiver> _logger;
        private readonly IPEndPoint _remoteEp;
        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();
        private readonly int _connectionTimeout;

        public HtspClientSendReceiver(string address, int port, bool ipv6, ILoggerFactory loggerFactory, int connectionTimeout)
        {
            _ipAddress = Dns.GetHostAddresses(address).First(d =>
                d.AddressFamily == (ipv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork));
            _remoteEp = new IPEndPoint(_ipAddress, port);
            _loggerFactory = loggerFactory;
            _connectionTimeout = connectionTimeout;
            _logger = _loggerFactory.CreateLogger<HtspClientSendReceiver>();
        }


        public void Dispose()
        {
            if (_connected)
                Disconnect();
            _cancel.Dispose();
            _client.Dispose();
        }

        public void Connect(Action<int, byte[]> messageReceiveCallback)
        {

            _client = new Socket(_ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            _client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            IAsyncResult result = _client.BeginConnect(_remoteEp, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(_connectionTimeout, true);
            if (success)
            {
                _client.EndConnect(result);
            }
            else
            {
                _client.Close();
                var msg = $"connection timeout when connecting to {_remoteEp.Address} port {_remoteEp.Port}";
                _logger.LogError(msg);
                throw new HtspException(msg);
            }


            StartReceiving(messageReceiveCallback);
            _connected = true;
        }

        public void Send(byte[] data)
        {
            _client.Send(data);
        }

        private void StartReceiving(Action<int, byte[]> messageReceiveCallback)
        {
            var state = new State(_loggerFactory);
            state.Consumer.StartConsuming(messageReceiveCallback, _cancel.Token);
            _client.BeginReceive(state.Buffer, 0, State.BufferSize, 0,
                ReceiveCallback, state);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                var state = (State)ar.AsyncState;


                // Read data from the remote device.  
                var bytesRead = _client.EndReceive(ar);


                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    var t = new byte[bytesRead];
                    Array.Copy(state.Buffer, t, bytesRead);
                    state.Consumer.Add(t, bytesRead);
                }

                _client.BeginReceive(state.Buffer, 0, State.BufferSize, 0,
                    ReceiveCallback, state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Disconnect()
        {
            _client.Shutdown(SocketShutdown.Both);
            _client.Close(10);
            _cancel.Cancel();
            _connected = false;
        }


        private class State
        {
            public const int BufferSize = 2048;

            public readonly byte[] Buffer = new byte[BufferSize];


            public readonly DataConsumer Consumer;

            public State(ILoggerFactory loggerFactory)
            {
                Consumer = new DataConsumer(loggerFactory.CreateLogger<DataConsumer>());
            }
        }
    }
}