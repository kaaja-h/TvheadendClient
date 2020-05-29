using System;
using System.IO;
using System.Net;
using Microsoft.Extensions.Logging;
using TvheadendClient.Messages;

namespace TvheadendClient.Serialization
{
    class Serializer
    {
        private readonly ILoggerFactory _factory;
        private readonly ILogger<Serializer> _logger;
        private readonly SerializerFactory _serializerFactory;
        public Serializer(ILoggerFactory factory)
        {
            _factory = factory;
            _logger = _factory.CreateLogger<Serializer>();
            _serializerFactory = new SerializerFactory(_factory);
        }

        public void Serialize(MessageBase message, Stream s)
        {
            var serializer = _serializerFactory.GetSerializerForType(typeof(MessageBase));
            var length = serializer.GetLength(message);
            var lenarray = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(length));
            s.Write(lenarray, 0, 4);
            serializer.Serialize(message, s);
        }

        public MessageBase Deserialize(int length, byte[] data)
        {
            var s = _serializerFactory.GetSerializerForType(HtspMessageItemType.Map);
            var res = s.Deserialize(data, 0, length) as DynamicMessage;
            return new MessageBase(res);
        }




    }


}