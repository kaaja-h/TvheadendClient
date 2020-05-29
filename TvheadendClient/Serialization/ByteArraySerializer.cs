using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{
    class ByteArraySerializer:SerializerBase<ByteArraySerializer,byte[]>
    {
        public ByteArraySerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory, loggerFactory)
        {
        }

        public override HtspMessageItemType MessageType => HtspMessageItemType.Bin;
        public override object Deserialize(byte[] data, int offset, int length)
        {
            var d = new byte[length];
            Array.Copy(data, offset, d, 0, length);
            return d;
        }

        protected override int GetLengthInner(byte[] o)
        {
            return o.Length;
        }

        protected override void SerializeInner(byte[] data, Stream s)
        {
            s.Write(data, 0, data.Length);
        }

        protected override bool NeedSerializationInner(byte[] o)
        {
            return o != null && o.Length > 0;
        }
    }
}