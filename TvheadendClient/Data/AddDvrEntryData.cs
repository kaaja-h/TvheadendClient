﻿using System;
using System.Xml.Schema;
using System.ComponentModel.DataAnnotations;
using TvheadendClient.Data.Implementation;
using TvheadendClient.Messages;

namespace TvheadendClient.Data
{
    public class AddDvrEntryData : MessageBase
    {
        public long? EventId => Get<long?>("eventId");
        public long? ChannelId => Get<long?>("channelId");
        public DateTime? Start => Get<long?>("start").FromUnixTimestamp();

        public DateTime? Stop => Get<long?>("stop").FromUnixTimestamp();

        public long? StartExtra
        {
            get => Get<long?>("startExtra");
            set => Set("startExtra", value);
        }

        public long? StopExtra
        {
            get => Get<long?>("stopExtra");
            set => Set("stopExtra", value);
        }

        public long? Retention
        {
            get => Get<long?>("retention");
            set => Set("retention", value);
        }

        public string Title
        {
            get => Get<string>("title");

        }

        public string Subtitle
        {
            get => Get<string>("subtitle");
            set => Set("subtitle", value);
        }

        public string Description
        {
            get => Get<string>("Description");
            set => Set("Description", value);
        }

        public bool Enabled
        {
            get => Get<long?>("enabled").GetValueOrDefault(0) == 1;
            set => Set("enabled", value ? 1 : 0);
        }


        public AddDvrEntryData(long eventId) : base("addDvrEntry")
        {
            Set("eventId", eventId);
        }

        public AddDvrEntryData(long channelId, DateTime start, DateTime stop, string title) : base("addDvrEntry")
        {
            Set("channelId", channelId);
            Set("start", start.ToUnixTimestamp());
            Set("stop", stop.ToUnixTimestamp());
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("title is needed", nameof(title));
            Set("title", title);

        }

        public AddDvrEntryData(IChannel channel, DateTime start, DateTime stop, string title) : this(channel.Id, start, stop, title)
        {

        }


    }


    public class UpdateDvrEntryData : MessageBase
    {
        public long Id => Get<long>("id");

        public long? ChannelId
        {
            get => Get<long?>("channelId");
            set => Set("channelId", value);
        }

        public DateTime? Start
        {
            get => Get<long?>("startExtra").FromUnixTimestamp();
            set => Set("startExtra", value.ToUnixTimestamp());
        }

        public DateTime? Stop
        {
            get => Get<long?>("stop").FromUnixTimestamp();
            set => Set("stop", value.ToUnixTimestamp());
        }

        public long? StartExtra
        {
            get => Get<long?>("startExtra");
            set => Set("startExtra", value);
        }

        public long? StopExtra
        {
            get => Get<long?>("stopExtra");
            set => Set("stopExtra", value);
        }

        public string Title
        {
            get => Get<string>("title");

        }

        public string Subtitle
        {
            get => Get<string>("subtitle");
            set => Set("subtitle", value);
        }

        public string Description
        {
            get => Get<string>("Description");
            set => Set("Description", value);
        }

        public bool Enabled
        {
            get => Get<long?>("enabled").GetValueOrDefault(0) == 1;
            set => Set("enabled", value ? 1 : 0);
        }

        public long? Retention
        {
            get => Get<long?>("retention");
            set => Set("retention", value);
        }

        public UpdateDvrEntryData(long id)
        {
            Set("id",id);
        }
    }
}