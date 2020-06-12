using System;

namespace TvheadendClient.Data.Dvr
{
    /// <summary>
    /// Dvr entry
    /// </summary>
    public interface IDvrEntry: IDataItem<long>
    {
        /// <summary>
        /// ChannelId
        /// </summary>
        long ChannelId { get; }

        /// <summary>
        /// Channel
        /// </summary>
        IChannel Channel { get; }

        /// <summary>
        /// Event
        /// </summary>
        IEpgEvent Event { get; }

        /// <summary>
        /// EventId
        /// </summary>
        long? EventId { get; }

        /// <summary>
        /// Start
        /// </summary>
        DateTime Start { get;  }

        /// <summary>
        /// Stop
        /// </summary>
        DateTime Stop { get;  }

        /// <summary>
        /// AutorecordingId
        /// </summary>
        string AutorecordId{get;}

        /// <summary>
        /// Autorecording
        /// </summary>
        IAutoRecordingEntry AutoRecordingEntry{get;}

        /// <summary>
        /// Description
        /// </summary>
        string Description{get;}

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Subtitle
        /// </summary>
        string Subtitle { get; }

        /// <summary>
        /// Summary
        /// </summary>
        string Summary { get; }

        /// <summary>
        /// State
        /// </summary>
        string State { get;  }

        /// <summary>
        /// Enabled
        /// </summary>
        bool Enabled {get;}

        /// <summary>
        /// Comment
        /// </summary>
        string Comment{get;}


        /// <summary>
        /// Time recording Id
        /// </summary>
        string TimeRecordingId { get; }


        /// <summary>
        /// Time recording
        /// </summary>
        ITimeRecording TimeRecording { get; }

        /// <summary>
        /// Extra time before start in minutes
        /// </summary>
        long? StartExtra { get; }

        /// <summary>
        /// Extra time after stop
        /// </summary>
        long? StopExtra { get; }

        /// <summary>
        /// recording retention in days
        /// </summary>
        long? Retention { get; }

        /// <summary>
        /// Recording priority
        /// </summary>
        long? Priority { get; }

        /// <summary>
        /// Content type id
        /// </summary>
        long? ContentTypeId { get; }

        /// <summary>
        /// Content type
        /// </summary>
        EpgContentType ContentType { get; }

        /// <summary>
        /// Image
        /// </summary>
        string Image { get; }

        /// <summary>
        /// Data size
        /// </summary>
        long? Datasize { get; }

    }
    
}