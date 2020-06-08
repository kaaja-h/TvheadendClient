using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    internal abstract class DataHolder<TIdType, TDataType, TInterfaceType> : IItems<TInterfaceType, TIdType>
        where TDataType : DataBase<TIdType>, TInterfaceType, new()
        where TInterfaceType : IDataItem<TIdType>
    {

        protected readonly TvheadendData TvData;
        protected readonly ConcurrentDictionary<TIdType, TDataType> data;
        protected readonly Client client;
        public IReadOnlyDictionary<TIdType, TInterfaceType> Items { get; private set; }
        public event EventHandler<ItemChangeEvent<TInterfaceType>> ItemDeleted;
        public event EventHandler<ItemChangeEvent<TInterfaceType>> ItemAdded;
        public event EventHandler<ItemChangeEvent<TInterfaceType>> ItemChanged;

        private readonly string _createMethod;
        private readonly string _updateMethod;
        private readonly string _deleteMethod;

        public DataHolder(TvheadendData data, string createMethod, string updateMethod, string deleteMethod, Client client)
        {
            TvData = data;
            this.client = client;
            _createMethod = createMethod;
            _updateMethod = updateMethod;
            _deleteMethod = deleteMethod;
            this.data = new ConcurrentDictionary<TIdType, TDataType>();
            Items = new InterfaceDictionary<TIdType, TDataType, TInterfaceType>(this.data);
        }


        protected abstract TIdType ExtractId(MessageBase msg);



        public void Create(MessageBase msg)
        {
            var id = ExtractId(msg);
            var res = new TDataType();
            res.Init(TvData, msg, id);
            data[id] = res;
            OnCreate(res);
            ItemAdded?.Invoke(this, new ItemChangeEvent<TInterfaceType>(res));
        }

        public void Update(MessageBase msg)
        {
            var id = ExtractId(msg);
            if (!Items.ContainsKey(id))
            {
                throw new Exception("invalid id");
            }

            var res = data[id];
            res.Update(msg);
            OnUpdate(res);
            ItemChanged?.Invoke(this, new ItemChangeEvent<TInterfaceType>(res));
        }

        public void UpdatedExternal(TIdType id)
        {
            if (!Items.ContainsKey(id))
            {
                return;
            }
            var res = data[id];
            OnUpdate(res);
            ItemChanged?.Invoke(this, new ItemChangeEvent<TInterfaceType>(res));
        }

        public void Delete(MessageBase msg)
        {
            var id = ExtractId(msg);
            if (!Items.ContainsKey(id))
            {
                throw new Exception("invalid id");
            }

            data.TryRemove(id, out var res);
            OnDelete(res);
            ItemDeleted?.Invoke(this, new ItemChangeEvent<TInterfaceType>(res));
        }

        public IEnumerable<(string, Action<MessageBase>)> GetActions()
        {
            yield return (_deleteMethod, Delete);
            yield return (_createMethod, Create);
            yield return (_updateMethod, Update);
        }

        protected virtual void OnCreate(TDataType data)
        {

        }

        protected virtual void OnUpdate(TDataType data)
        {

        }

        protected virtual void OnDelete(TDataType data)
        {

        }



    }


}