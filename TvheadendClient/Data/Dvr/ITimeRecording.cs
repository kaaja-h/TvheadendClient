namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Time recording entry
    /// </summary>
    public interface ITimeRecording : IDataItem<string>
    {
        /// <summary>
        /// Recording title (naming of result)
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Enabled
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Time recording name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Channel Id
        /// </summary>
        long ChannelId { get; }
        /// <summary>
        /// Channel
        /// </summary>
        IChannel Channel { get; }

        /// <summary>
        /// Days of week (can contains multiple days) 
        /// </summary>
        /// <example><code language="csharp">
        /// (DaysOfWeek &amp; DaysOfWeek.Tuesday) == DaysOfWeek.Tuesday
        /// </code>
        /// </example>
        DaysOfWeek DaysOfWeek { get; }
        /// <summary>
        /// Time recording start in munutes from midnight
        /// </summary>
        long Start { get; }
        /// <summary>
        /// Time recording start in munutes from midnight
        /// </summary>
        long Stop { get; }
        /// <summary>
        /// Recording retention in days
        /// </summary>
        long Retention { get; }

    }
}