namespace TvheadendClient.Data
{
    public interface IAutoRecord: IDataItem<string>
    {
        
        bool Enabled { get;  }
        string Title { get; }
        string Name { get; }

        long? ChannelId{get;}

        IChannel Channel{get;}

        bool Fulltext { get; }


    }
}