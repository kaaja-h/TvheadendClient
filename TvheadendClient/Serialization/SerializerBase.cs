using System.IO;
using Microsoft.Extensions.Logging;

namespace TvheadendClient.Serialization
{
    abstract class SerializerBase
    {

        private readonly SerializerFactory _serializerFactory;
        public SerializerBase(SerializerFactory serializerFactory)
        {
            _serializerFactory = serializerFactory;
        }

        public abstract int GetLength(object o);

        public abstract void Serialize(object o, Stream s);

        public abstract bool NeedSerialization(object o);

        public abstract HtspMessageItemType MessageType { get; }

        internal SerializerBase GetSerializer(object o)
        {
            return _serializerFactory.GetSerializerForType(o.GetType());
        }

        internal SerializerBase GetSerializer(HtspMessageItemType type)
        {
            return _serializerFactory.GetSerializerForType(type);
        }

        public abstract object Deserialize(byte[] data, int offset, int length);



        
    }

    abstract class SerializerBase<T, L> : SerializerBase where T : SerializerBase
    {
        protected readonly ILogger<T> Logger;

        public SerializerBase(SerializerFactory serializerFactory, ILoggerFactory loggerFactory) : base(serializerFactory)
        {
            Logger = loggerFactory.CreateLogger<T>();
        }

        protected abstract int GetLengthInner(L o);

        public override int GetLength(object o)
        {
            return GetLengthInner((L) o);
        }

        public override void Serialize(object o, Stream s)
        {
                SerializeInner((L) o,s);
        }

        protected abstract void SerializeInner(L o, Stream s);


        protected abstract bool NeedSerializationInner(L o);

        public override bool NeedSerialization(object o)
        {
            return NeedSerializationInner((L) o);
        }

        
    }
}