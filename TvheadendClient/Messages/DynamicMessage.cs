using System;
using System.Collections.Generic;
using System.Dynamic;

namespace TvheadendClient.Messages
{
    public class DynamicMessage : DynamicObject
    {
        internal Dictionary<string, object> Data = new Dictionary<string, object>();

        private static string Normalize(string name)
        {
            return Char.ToLowerInvariant(name[0]) + name.Substring(1);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return Data.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = Normalize(binder.Name);
            return Data.TryGetValue(name, out result);
        }

        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            Data[Normalize(binder.Name)] = value;
            return true;
        }

        public override bool TrySetIndex(
            SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length != 1)
                return false;

            var name = indexes[0] as string;
            if (name == null)
                return false;
            name = Normalize(name);
            Data[name] = value;
            return true;
        }

        public override bool TryGetIndex(
            GetIndexBinder binder, object[] indexes, out object result)
        {
            result = null;
            if (indexes.Length != 1)
                return false;

            var name = indexes[0] as string;
            if (name == null)
                return false;
            name = Normalize(name);
            return Data.TryGetValue(name, out result);
        }


        public T Get<T>(string name, T def=default)
        {
            name = Normalize(name);
            if (Data.ContainsKey(name))
            {
                return (T) Data[name];
            }
            return def;
        }



        public void Set(string name, object value)
        {
            Data[Normalize(name)] = value;
        }

        
    }
}