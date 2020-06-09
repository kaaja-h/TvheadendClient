using System;
using System.Collections.Generic;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Items storage
    /// </summary>
    /// <typeparam name="TInterfaceType"></typeparam>
    /// <typeparam name="TIdType"></typeparam>
    public interface IItems<TInterfaceType, TIdType>:
        IReadOnlyDictionary<TIdType, TInterfaceType>
        where TInterfaceType : IDataItem<TIdType>
    {

        /// <summary>
        /// Event is raised when item is deleted
        /// </summary>
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemDeleted;
        /// <summary>
        /// Event is raised when new item is added
        /// </summary>
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemAdded;

        /// <summary>
        /// event is raised when item is modified
        /// </summary>
        event EventHandler<ItemChangeEvent<TInterfaceType>> ItemChanged;

        
    }
}