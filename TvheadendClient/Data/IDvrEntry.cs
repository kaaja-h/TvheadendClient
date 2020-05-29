using System;

namespace TvheadendClient.Data
{
    public interface IDvrEntry: IDataItem<long>
    {
        
        long ChannelId { get; }
        IChannel Channel { get; }

        IEpgEvent Event { get; }
        long? EventId { get; }

        DateTime Start { get;  }

        DateTime Stop { get;  }

        string AutorecordId{get;}

        IAutoRecord AutoRecord{get;}

        string Description{get;}

        string Title { get; }

        string Subtitle { get; }

        string Summary { get; }


        string State { get;  }

        bool Enabled {get;}

        string Comment{get;}


    }
}