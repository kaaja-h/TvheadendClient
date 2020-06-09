using System;
using System.Collections.Generic;
using TvheadendClient.Data.Dvr;

namespace TvheadendClient.Data
{
    /// <summary>
    /// Epg event data
    /// </summary>
    public interface IEpgEvent: IDataItem<long>
    {
        /// <summary>
        /// Channel
        /// </summary>
        IChannel Channel { get; }
        /// <summary>
        /// Channel id
        /// </summary>
        long ChannelId { get;  }
        /// <summary>
        /// Event title
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Event summary
        /// </summary>
        string Summary { get; }
        /// <summary>
        /// Event description
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Event start
        /// </summary>
        DateTime Start { get; }
        /// <summary>
        /// Event stop
        /// </summary>
        DateTime Stop { get; }
        /// <summary>
        /// Content type Id
        /// </summary>
        long? ContentTypeId { get; }
        /// <summary>
        /// Content Type
        /// </summary>
        EpgContentType ContentType { get; }

        /// <summary>
        /// Related Dvr entries
        /// </summary>
        IReadOnlyCollection<IDvrEntry> DvrEntries { get; }


    }
}