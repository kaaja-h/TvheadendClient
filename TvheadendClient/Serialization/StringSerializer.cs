using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{
    class StringSerializer:SerializerBase<StringSerializer,string>
    {
        public StringSerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory, loggerFactory)
        {
        }

        public override HtspMessageItemType MessageType => HtspMessageItemType.Str;
        public override object Deserialize(byte[] data, int offset, int length)
        {
            return Encoding.UTF8.GetString(data, offset, length);
        }

        protected override int GetLengthInner(string o)
        {
            return Encoding.UTF8.GetByteCount(o);
        }

        protected override void SerializeInner(string o, Stream s)
        {
            var data = Encoding.UTF8.GetBytes(o);
            s.Write(data, 0, data.Length);
        }

        protected override bool NeedSerializationInner(string o)
        {
            return !string.IsNullOrEmpty(o);
        }
    }
}