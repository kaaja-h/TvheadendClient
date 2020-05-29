using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{
    abstract class CollectionSerializer<T,L> : SerializerBase<T,L> where T: SerializerBase
    {
        protected CollectionSerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory, loggerFactory)
        {
        }

        private static void ReadItem(byte[] data, int offset, out int readed, out string name, out int dataLength,
            out HtspMessageItemType type)
        {
            type = (HtspMessageItemType)data[offset];
            offset++;
            var nameLength = data[offset];
            offset++;
            var d = new byte[4];
            Array.Copy(data, offset, d, 0, 4);
            dataLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(d, 0));
            offset += 4;
            name = "";
            if (nameLength > 0) name = Encoding.UTF8.GetString(data, offset, nameLength);
            readed = 1 + 1 + 4 + nameLength;
        }

        internal static IEnumerable<ListItem> ListItems(byte[] data, int offset, int length)
        {
            var readedTotal = 0;
            while (readedTotal < length)
            {
                ReadItem(data, offset, out var readed, out var name, out var itemLength, out var type);

                offset += readed;
                readedTotal += readed;
                yield return new ListItem
                {
                    DataLength = itemLength,
                    DataOffset = offset,
                    Type = type,
                    Name = name
                };

                offset += itemLength;
                readedTotal += itemLength;
            }
        }

        
    }
}