using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TvheadendClient.Data.Implementation
{
    internal class InterfaceDictionary<KeyType, ValueType, InterfaceType>: IReadOnlyDictionary<KeyType, InterfaceType>
    where ValueType: InterfaceType
    {
        private readonly ConcurrentDictionary<KeyType, ValueType> _data;
        public InterfaceDictionary(ConcurrentDictionary<KeyType, ValueType> data)
        {
            _data = data;
        }
        public IEnumerator<KeyValuePair<KeyType, InterfaceType>> GetEnumerator()
        {
            return _data.Select(a => new KeyValuePair<KeyType, InterfaceType>(a.Key, a.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.Select(a => new KeyValuePair<KeyType, InterfaceType>(a.Key, a.Value)).GetEnumerator();
        }

        public int Count => _data.Count;
        public bool ContainsKey(KeyType key)
        {
            return _data.ContainsKey(key);
        }

        public bool TryGetValue(KeyType key, out InterfaceType value)
        {
            var res=  _data.TryGetValue(key, out var v);
            value = v;
            return res;
        }

        public InterfaceType this[KeyType key] => _data[key];

        public IEnumerable<KeyType> Keys => _data.Keys;

        public IEnumerable<InterfaceType> Values => _data.Values.Cast<InterfaceType>();
    }
}