using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{
    class ArraySerializer:CollectionSerializer<ArraySerializer,IEnumerable>
    {
        public ArraySerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory, loggerFactory)
        {
        }

        public override HtspMessageItemType MessageType => HtspMessageItemType.List;


        protected override int GetLengthInner(IEnumerable o)
        {
            var len = 0;

            foreach (var item in o)
            {
                var s = GetSerializer(item);
                if (s.NeedSerialization(item))
                    len += 1 + 1 + 4 + s.GetLength(item);
            }
            return len;
        }

        protected override void SerializeInner(IEnumerable o, Stream s)
        {
            
            foreach (var item in o)
            {
                var serializer = GetSerializer(item);
                if (!serializer.NeedSerialization(item))
                    continue;
                s.WriteByte((byte)serializer.MessageType);
                s.WriteByte(0);
                var len = serializer.GetLength(item);
                var lenArray = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(len));
                s.Write(lenArray, 0, 4);
                serializer.Serialize(item, s);
            }
        }

        protected override bool NeedSerializationInner(IEnumerable o)
        {
            if (o == null)
                return false;
            foreach (var _ in o)
            {
                return true;
            }

            return false;
        }

        public override object Deserialize(byte[] data, int offset, int length)
        {
            var items = ListItems(data, offset, length).ToList();
            if (!items.Any())
                return null;
            var result = new List<object>();
            foreach (var item in items)
            {
                var serializer = GetSerializer(item.Type);
                var value = serializer.Deserialize(data, item.DataOffset, item.DataLength);
                result.Add(value);
            }

            if (items.All(d => d.Type == HtspMessageItemType.Str))
                return result.Cast<string>().ToArray();
            if (items.All(d => d.Type == HtspMessageItemType.Bin))
                return result.Cast<byte[]>().ToArray();
            if (items.All(d => d.Type == HtspMessageItemType.S64))
                return result.Cast<long>().ToArray();
            return result.ToArray();
        }

    }
}