namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Dvr configuration item
    /// </summary>
    public interface IDvrConfiguration:IDataItem<string>
    {
        /// <summary>
        /// Dvr configuration item name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Comment
        /// </summary>
        string Comment { get; }
    }
}