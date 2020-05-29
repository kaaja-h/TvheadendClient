namespace TvheadendClient.Data
{
    public interface IDataItem<out TId> :IDataItem
    {
        TId Id { get; }
    }

    public interface IDataItem
    {

    }
}