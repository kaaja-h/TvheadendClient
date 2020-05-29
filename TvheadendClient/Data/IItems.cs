using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    public interface IItems<TInterfaceType, TIdType> where TInterfaceType : IDataItem<TIdType>
    {
        IReadOnlyDictionary<TIdType, TInterfaceType> Items { get; }
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemDeleted;
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemAdded;
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemChanged;

        void UpdatedExternal(TIdType id);
    }
}