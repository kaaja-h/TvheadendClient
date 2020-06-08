namespace TvheadendClient.Data
{
    public interface IDvrConfiguration:IDataItem<string>
    {
        string Name { get; }
        string Comment { get; }
    }
}