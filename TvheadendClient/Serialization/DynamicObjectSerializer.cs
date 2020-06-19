using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using TvheadendClient.Exceptions;
using TvheadendClient.Messages;

namespace TvheadendClient.Serialization
{
    class DynamicObjectSerializer: CollectionSerializer<DynamicObjectSerializer, DynamicMessageItem>
    {
        public DynamicObjectSerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory, loggerFactory)
        {
        }

        protected override int GetLengthInner(DynamicMessageItem data)
        {
            if (data==null)
                throw  new HtspMessageException("invalid data");
            var res = 0;
            foreach (var item in data.GetDynamicMemberNames())
            {
                var value = data.Data[item];
                var s = this.GetSerializer(value);
                if (s.NeedSerialization(value))
                    res += 1 + 1 + 4 + Encoding.UTF8.GetByteCount(item) + s.GetLength(value);
            }
            return res;
        }

        protected override void SerializeInner(DynamicMessageItem data, Stream s)
        {
            
            foreach (var item in data.Data.Keys)
            {
                var value = data.Data[item];
                var serializer = GetSerializer(value);
                if (!serializer.NeedSerialization(value))
                    continue;
                s.WriteByte((byte)serializer.MessageType);
                s.WriteByte((byte)Encoding.UTF8.GetByteCount(item));
                var len = serializer.GetLength(value);
                var lenArray = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(len));
                s.Write(lenArray, 0, 4);
                var nameArray = Encoding.UTF8.GetBytes(item);
                s.Write(nameArray, 0, nameArray.Length);
                serializer.Serialize(value, s);
            }
        }

        protected override bool NeedSerializationInner(DynamicMessageItem data)
        {
            return data == null;
        }

        public override HtspMessageItemType MessageType => HtspMessageItemType.Map;
        public override object Deserialize(byte[] data, int offset, int length)
        {
            var items = ListItems(data, offset, length).ToArray();
            var output = new DynamicMessageItem();
            foreach (var item in items)
            {
                var serializer = GetSerializer(item.Type);
                var value = serializer.Deserialize(data, item.DataOffset, item.DataLength);
                output.InnerSet(item.Name,value);
            }
            return output;
        }
    }
}