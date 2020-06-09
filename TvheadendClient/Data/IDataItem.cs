namespace TvheadendClient.Data
{
    /// <summary>
    /// Tvheadend data item with id
    /// </summary>
    /// <typeparam name="TId">type of Id</typeparam>
    public interface IDataItem<out TId> :IDataItem
    {
        /// <summary>
        /// Id
        /// </summary>
        TId Id { get; }
    }

    /// <summary>
    /// Tvheadend data item
    /// </summary>
    public interface IDataItem
    {

    }
}