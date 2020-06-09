using System;
using System.Collections.Generic;
using System.Dynamic;

namespace TvheadendClient.Messages
{
    /// <summary>
    /// Dynamic message item for comunicating with server
    /// </summary>
    public class DynamicMessageItem : DynamicObject
    {
        internal Dictionary<string, object> Data = new Dictionary<string, object>();

        private static string Normalize(string name)
        {
            return Char.ToLowerInvariant(name[0]) + name.Substring(1);
        }
        
        /// <see cref="DynamicObject"/>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return Data.Keys;
        }

        /// <see cref="DynamicObject"/>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = Normalize(binder.Name);
            return Data.TryGetValue(name, out result);
        }

        /// <see cref="DynamicObject"/>
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            Data[Normalize(binder.Name)] = value;
            return true;
        }

        /// <see cref="DynamicObject"/>
        public override bool TrySetIndex(
            SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length != 1)
                return false;

            if (!(indexes[0] is string name))
                return false;
            name = Normalize(name);
            Data[name] = value;
            return true;
        }

        /// <see cref="DynamicObject"/>
        public override bool TryGetIndex(
            GetIndexBinder binder, object[] indexes, out object result)
        {
            result = null;
            if (indexes.Length != 1)
                return false;

            if (!(indexes[0] is string name))
                return false;
            name = Normalize(name);
            return Data.TryGetValue(name, out result);
        }

        /// <summary>
        /// Get child value 
        /// </summary>
        /// <typeparam name="T">child type from server -  can be received only long?, string, byte[], DynamicMessageItem or array of this types</typeparam>
        /// <param name="name">property name</param>
        /// <param name="def">default value</param>
        /// <returns></returns>
        public T Get<T>(string name, T def=default)
        {
            name = Normalize(name);
            if (Data.ContainsKey(name))
            {
                return (T) Data[name];
            }
            return def;
        }


        /// <summary>
        /// Set value  - to server can be send only long?, int?, string, byte[], DynamicMessageItem or array of this types
        /// </summary>
        /// <param name="name">property name</param>
        /// <param name="value">value</param>
        public void Set(string name, object value)
        {
            Data[Normalize(name)] = value;
        }

        
    }
}