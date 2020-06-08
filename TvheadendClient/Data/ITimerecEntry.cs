namespace TvheadendClient.Data
{
    public interface ITimerecEntry : IDataItem<string>
    {
        string Title { get; }
        bool Enabled { get; }
        string Name { get; }
        long ChannelId { get; }
        IChannel Channel { get; }
        DaysOfWeek DaysOfWeek { get; }
        long Start { get; }
        long Stop { get; }
        long Retention { get; }

    }
}