using System;
using System.Collections;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TvheadendClient.Exceptions;
using TvheadendClient.Messages;

namespace TvheadendClient.Serialization
{
    class SerializerFactory
    {

        private readonly ILoggerFactory _factory;

        public SerializerFactory(ILoggerFactory factory)
        {
            _factory = factory;

        }


        private readonly ConcurrentDictionary<Type, SerializerBase> _serializerCache = new ConcurrentDictionary<Type, SerializerBase>();
        private readonly ConcurrentDictionary<HtspMessageItemType, SerializerBase> _serializerByType = new ConcurrentDictionary<HtspMessageItemType, SerializerBase>();

        public SerializerBase GetSerializerForType(Type t)
        {
            return _serializerCache.GetOrAdd(t, GetSerializerForTypeInner);
        }

        private SerializerBase GetSerializerForTypeInner(Type t)
        {
            if (typeof(byte[]).IsAssignableFrom(t))
            {
                return new ByteArraySerializer(this, _factory);
            }
            
            if (typeof(long?).IsAssignableFrom(t) )
            {
                return new NumberSerializer<long?>(this, _factory, l => l);
            }
            if (typeof(int?).IsAssignableFrom(t))
            {
                return new NumberSerializer<int?>(this, _factory, l => l); ;
            }

            if (typeof(string).IsAssignableFrom(t))
            {
                return new StringSerializer(this, _factory);
            }
            if (typeof(IEnumerable).IsAssignableFrom(t))
            {
                return new ArraySerializer(this, _factory);
            }

            return new DynamicObjectSerializer(this, _factory);
        }

        public SerializerBase GetSerializerForType(HtspMessageItemType type)
        {
            return _serializerByType.GetOrAdd(type, t =>
            {
                switch (t)
                {
                    case HtspMessageItemType.S64:
                        return GetSerializerForType(typeof(long?));
                    case HtspMessageItemType.Str:
                        return GetSerializerForType(typeof(string));
                    case HtspMessageItemType.Bin:
                        return GetSerializerForType(typeof(byte[]));
                    case HtspMessageItemType.List:
                        return GetSerializerForType(typeof(IEnumerable));
                    case HtspMessageItemType.Map:
                        return GetSerializerForType(typeof(DynamicMessageItem));
                }
                throw new HtspMessageException("chyba");
            });
        }

    }
}