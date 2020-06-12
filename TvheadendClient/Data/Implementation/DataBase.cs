using System;
using TvheadendClient.Messages;

namespace TvheadendClient.Data.Implementation
{
    abstract class DataBase< TIdType >
    {
        protected TvheadendData Data { get; private set; }

        public TIdType Id { get; private set; }


        internal void Init(TvheadendData data, MessageBase msg, TIdType id)
        {
            Data = data;
            Id = id;
            UpdateInternal(msg);
        }

        internal DataBase()
        {

        }

        internal void Update(MessageBase data)
        {
            UpdateInternal(data);
        }

        protected abstract void UpdateInternal(MessageBase data);


    }
}