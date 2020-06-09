using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{

    class NumberSerializer<L> : SerializerBase<NumberSerializer<L>, L>

    {
        private Func<L, long?> _convertor;
        public override HtspMessageItemType MessageType => HtspMessageItemType.S64;
        internal NumberSerializer(SerializerFactory serializerFactory, ILoggerFactory loggerFactory, Func<L,long?> convertor) : base(serializerFactory, loggerFactory)
        {
            _convertor = convertor;
        }



        public override object Deserialize(byte[] data, int offset, int length)
        {
            var d = new byte[8];
            Array.Copy(data, offset, d, 0, length);
            long? res = BitConverter.ToInt64(d, 0);
            return res;
        }

        private static int Length(long l)
        {
            var tmp = l;
            var length = 0;
            while (tmp != 0)
            {
                tmp >>= 8;
                length++;
            }

            if (length == 0)
                length++;
            return length;
        }

        protected override int GetLengthInner(L value)
        {
            var o = _convertor(value);
            return (Length(o.GetValueOrDefault()));
        }

        protected override void SerializeInner(L value, Stream s)
        {
            var o = _convertor(value);
            var val = o.GetValueOrDefault();
            var data = BitConverter.GetBytes(val);
            s.Write(data, 0, Length(val));
        }

        protected override bool NeedSerializationInner(L value)
        {
            var o = _convertor(value);
            return o.HasValue;
        }
    }

    
}