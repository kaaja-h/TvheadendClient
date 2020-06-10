<a name='assembly'></a>
# TvheadendClient

## Contents

- [AddDvrEntryData](#T-TvheadendClient-Data-Dvr-AddDvrEntryData 'TvheadendClient.Data.Dvr.AddDvrEntryData')
  - [#ctor(eventId)](#M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-System-Int64- 'TvheadendClient.Data.Dvr.AddDvrEntryData.#ctor(System.Int64)')
  - [#ctor(channelId,start,stop,title)](#M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-System-Int64,System-DateTime,System-DateTime,System-String- 'TvheadendClient.Data.Dvr.AddDvrEntryData.#ctor(System.Int64,System.DateTime,System.DateTime,System.String)')
  - [#ctor(channel,start,stop,title)](#M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-TvheadendClient-Data-IChannel,System-DateTime,System-DateTime,System-String- 'TvheadendClient.Data.Dvr.AddDvrEntryData.#ctor(TvheadendClient.Data.IChannel,System.DateTime,System.DateTime,System.String)')
  - [ChannelId](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-ChannelId 'TvheadendClient.Data.Dvr.AddDvrEntryData.ChannelId')
  - [Description](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Description 'TvheadendClient.Data.Dvr.AddDvrEntryData.Description')
  - [Enabled](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Enabled 'TvheadendClient.Data.Dvr.AddDvrEntryData.Enabled')
  - [EventId](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-EventId 'TvheadendClient.Data.Dvr.AddDvrEntryData.EventId')
  - [Priority](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Priority 'TvheadendClient.Data.Dvr.AddDvrEntryData.Priority')
  - [Retention](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Retention 'TvheadendClient.Data.Dvr.AddDvrEntryData.Retention')
  - [Start](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Start 'TvheadendClient.Data.Dvr.AddDvrEntryData.Start')
  - [StartExtra](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-StartExtra 'TvheadendClient.Data.Dvr.AddDvrEntryData.StartExtra')
  - [Stop](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Stop 'TvheadendClient.Data.Dvr.AddDvrEntryData.Stop')
  - [StopExtra](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-StopExtra 'TvheadendClient.Data.Dvr.AddDvrEntryData.StopExtra')
  - [Subtitle](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Subtitle 'TvheadendClient.Data.Dvr.AddDvrEntryData.Subtitle')
  - [Title](#P-TvheadendClient-Data-Dvr-AddDvrEntryData-Title 'TvheadendClient.Data.Dvr.AddDvrEntryData.Title')
- [Client](#T-TvheadendClient-Client 'TvheadendClient.Client')
  - [#ctor(options)](#M-TvheadendClient-Client-#ctor-TvheadendClient-ClientOptions- 'TvheadendClient.Client.#ctor(TvheadendClient.ClientOptions)')
  - [#ctor(options,loggerFactory)](#M-TvheadendClient-Client-#ctor-TvheadendClient-ClientOptions,Microsoft-Extensions-Logging-ILoggerFactory- 'TvheadendClient.Client.#ctor(TvheadendClient.ClientOptions,Microsoft.Extensions.Logging.ILoggerFactory)')
  - [Connected](#P-TvheadendClient-Client-Connected 'TvheadendClient.Client.Connected')
  - [Data](#P-TvheadendClient-Client-Data 'TvheadendClient.Client.Data')
  - [Connect()](#M-TvheadendClient-Client-Connect 'TvheadendClient.Client.Connect')
  - [Disconnect()](#M-TvheadendClient-Client-Disconnect 'TvheadendClient.Client.Disconnect')
  - [Dispose()](#M-TvheadendClient-Client-Dispose 'TvheadendClient.Client.Dispose')
- [ClientOptions](#T-TvheadendClient-ClientOptions 'TvheadendClient.ClientOptions')
  - [#ctor()](#M-TvheadendClient-ClientOptions-#ctor 'TvheadendClient.ClientOptions.#ctor')
  - [Culture](#P-TvheadendClient-ClientOptions-Culture 'TvheadendClient.ClientOptions.Culture')
  - [Host](#P-TvheadendClient-ClientOptions-Host 'TvheadendClient.ClientOptions.Host')
  - [Ipv6](#P-TvheadendClient-ClientOptions-Ipv6 'TvheadendClient.ClientOptions.Ipv6')
  - [Password](#P-TvheadendClient-ClientOptions-Password 'TvheadendClient.ClientOptions.Password')
  - [Port](#P-TvheadendClient-ClientOptions-Port 'TvheadendClient.ClientOptions.Port')
  - [UserName](#P-TvheadendClient-ClientOptions-UserName 'TvheadendClient.ClientOptions.UserName')
- [DaysOfWeek](#T-TvheadendClient-Data-DaysOfWeek 'TvheadendClient.Data.DaysOfWeek')
  - [Everyday](#F-TvheadendClient-Data-DaysOfWeek-Everyday 'TvheadendClient.Data.DaysOfWeek.Everyday')
  - [Friday](#F-TvheadendClient-Data-DaysOfWeek-Friday 'TvheadendClient.Data.DaysOfWeek.Friday')
  - [Monday](#F-TvheadendClient-Data-DaysOfWeek-Monday 'TvheadendClient.Data.DaysOfWeek.Monday')
  - [Saturday](#F-TvheadendClient-Data-DaysOfWeek-Saturday 'TvheadendClient.Data.DaysOfWeek.Saturday')
  - [Sunday](#F-TvheadendClient-Data-DaysOfWeek-Sunday 'TvheadendClient.Data.DaysOfWeek.Sunday')
  - [Thursday](#F-TvheadendClient-Data-DaysOfWeek-Thursday 'TvheadendClient.Data.DaysOfWeek.Thursday')
  - [Tuesday](#F-TvheadendClient-Data-DaysOfWeek-Tuesday 'TvheadendClient.Data.DaysOfWeek.Tuesday')
  - [Wednesday](#F-TvheadendClient-Data-DaysOfWeek-Wednesday 'TvheadendClient.Data.DaysOfWeek.Wednesday')
- [DynamicMessageItem](#T-TvheadendClient-Messages-DynamicMessageItem 'TvheadendClient.Messages.DynamicMessageItem')
  - [GetDynamicMemberNames()](#M-TvheadendClient-Messages-DynamicMessageItem-GetDynamicMemberNames 'TvheadendClient.Messages.DynamicMessageItem.GetDynamicMemberNames')
  - [Get\`\`1(name,def)](#M-TvheadendClient-Messages-DynamicMessageItem-Get``1-System-String,``0- 'TvheadendClient.Messages.DynamicMessageItem.Get``1(System.String,``0)')
  - [Set(name,value)](#M-TvheadendClient-Messages-DynamicMessageItem-Set-System-String,System-Object- 'TvheadendClient.Messages.DynamicMessageItem.Set(System.String,System.Object)')
  - [TryGetIndex()](#M-TvheadendClient-Messages-DynamicMessageItem-TryGetIndex-System-Dynamic-GetIndexBinder,System-Object[],System-Object@- 'TvheadendClient.Messages.DynamicMessageItem.TryGetIndex(System.Dynamic.GetIndexBinder,System.Object[],System.Object@)')
  - [TryGetMember()](#M-TvheadendClient-Messages-DynamicMessageItem-TryGetMember-System-Dynamic-GetMemberBinder,System-Object@- 'TvheadendClient.Messages.DynamicMessageItem.TryGetMember(System.Dynamic.GetMemberBinder,System.Object@)')
  - [TrySetIndex()](#M-TvheadendClient-Messages-DynamicMessageItem-TrySetIndex-System-Dynamic-SetIndexBinder,System-Object[],System-Object- 'TvheadendClient.Messages.DynamicMessageItem.TrySetIndex(System.Dynamic.SetIndexBinder,System.Object[],System.Object)')
  - [TrySetMember()](#M-TvheadendClient-Messages-DynamicMessageItem-TrySetMember-System-Dynamic-SetMemberBinder,System-Object- 'TvheadendClient.Messages.DynamicMessageItem.TrySetMember(System.Dynamic.SetMemberBinder,System.Object)')
- [EpgContentType](#T-TvheadendClient-Data-EpgContentType 'TvheadendClient.Data.EpgContentType')
  - [ContentTypes](#P-TvheadendClient-Data-EpgContentType-ContentTypes 'TvheadendClient.Data.EpgContentType.ContentTypes')
  - [DefaultContentTypes](#P-TvheadendClient-Data-EpgContentType-DefaultContentTypes 'TvheadendClient.Data.EpgContentType.DefaultContentTypes')
  - [Level1](#P-TvheadendClient-Data-EpgContentType-Level1 'TvheadendClient.Data.EpgContentType.Level1')
  - [Level1Description](#P-TvheadendClient-Data-EpgContentType-Level1Description 'TvheadendClient.Data.EpgContentType.Level1Description')
  - [Level2](#P-TvheadendClient-Data-EpgContentType-Level2 'TvheadendClient.Data.EpgContentType.Level2')
  - [Level2Description](#P-TvheadendClient-Data-EpgContentType-Level2Description 'TvheadendClient.Data.EpgContentType.Level2Description')
  - [Value](#P-TvheadendClient-Data-EpgContentType-Value 'TvheadendClient.Data.EpgContentType.Value')
- [HtspException](#T-TvheadendClient-Exceptions-HtspException 'TvheadendClient.Exceptions.HtspException')
- [HtspMessageException](#T-TvheadendClient-Exceptions-HtspMessageException 'TvheadendClient.Exceptions.HtspMessageException')
- [IAutoRecordingEntry](#T-TvheadendClient-Data-Dvr-IAutoRecordingEntry 'TvheadendClient.Data.Dvr.IAutoRecordingEntry')
  - [Channel](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Channel 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.Channel')
  - [ChannelId](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-ChannelId 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.ChannelId')
  - [Enabled](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Enabled 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.Enabled')
  - [Fulltext](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Fulltext 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.Fulltext')
  - [Name](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Name 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.Name')
  - [Title](#P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Title 'TvheadendClient.Data.Dvr.IAutoRecordingEntry.Title')
- [IAutoRecordingStorage](#T-TvheadendClient-Data-Dvr-IAutoRecordingStorage 'TvheadendClient.Data.Dvr.IAutoRecordingStorage')
- [IChannel](#T-TvheadendClient-Data-IChannel 'TvheadendClient.Data.IChannel')
  - [Events](#P-TvheadendClient-Data-IChannel-Events 'TvheadendClient.Data.IChannel.Events')
  - [Icon](#P-TvheadendClient-Data-IChannel-Icon 'TvheadendClient.Data.IChannel.Icon')
  - [Name](#P-TvheadendClient-Data-IChannel-Name 'TvheadendClient.Data.IChannel.Name')
  - [Number](#P-TvheadendClient-Data-IChannel-Number 'TvheadendClient.Data.IChannel.Number')
  - [NumberMinor](#P-TvheadendClient-Data-IChannel-NumberMinor 'TvheadendClient.Data.IChannel.NumberMinor')
  - [TagIds](#P-TvheadendClient-Data-IChannel-TagIds 'TvheadendClient.Data.IChannel.TagIds')
  - [Tags](#P-TvheadendClient-Data-IChannel-Tags 'TvheadendClient.Data.IChannel.Tags')
- [IChannelStorage](#T-TvheadendClient-Data-IChannelStorage 'TvheadendClient.Data.IChannelStorage')
- [IDataItem](#T-TvheadendClient-Data-IDataItem 'TvheadendClient.Data.IDataItem')
- [IDataItem\`1](#T-TvheadendClient-Data-IDataItem`1 'TvheadendClient.Data.IDataItem`1')
  - [Id](#P-TvheadendClient-Data-IDataItem`1-Id 'TvheadendClient.Data.IDataItem`1.Id')
- [IDvrConfiguration](#T-TvheadendClient-Data-Dvr-IDvrConfiguration 'TvheadendClient.Data.Dvr.IDvrConfiguration')
  - [Comment](#P-TvheadendClient-Data-Dvr-IDvrConfiguration-Comment 'TvheadendClient.Data.Dvr.IDvrConfiguration.Comment')
  - [Name](#P-TvheadendClient-Data-Dvr-IDvrConfiguration-Name 'TvheadendClient.Data.Dvr.IDvrConfiguration.Name')
- [IDvrEntry](#T-TvheadendClient-Data-Dvr-IDvrEntry 'TvheadendClient.Data.Dvr.IDvrEntry')
  - [AutoRecordingEntry](#P-TvheadendClient-Data-Dvr-IDvrEntry-AutoRecordingEntry 'TvheadendClient.Data.Dvr.IDvrEntry.AutoRecordingEntry')
  - [AutorecordId](#P-TvheadendClient-Data-Dvr-IDvrEntry-AutorecordId 'TvheadendClient.Data.Dvr.IDvrEntry.AutorecordId')
  - [Channel](#P-TvheadendClient-Data-Dvr-IDvrEntry-Channel 'TvheadendClient.Data.Dvr.IDvrEntry.Channel')
  - [ChannelId](#P-TvheadendClient-Data-Dvr-IDvrEntry-ChannelId 'TvheadendClient.Data.Dvr.IDvrEntry.ChannelId')
  - [Comment](#P-TvheadendClient-Data-Dvr-IDvrEntry-Comment 'TvheadendClient.Data.Dvr.IDvrEntry.Comment')
  - [Description](#P-TvheadendClient-Data-Dvr-IDvrEntry-Description 'TvheadendClient.Data.Dvr.IDvrEntry.Description')
  - [Enabled](#P-TvheadendClient-Data-Dvr-IDvrEntry-Enabled 'TvheadendClient.Data.Dvr.IDvrEntry.Enabled')
  - [Event](#P-TvheadendClient-Data-Dvr-IDvrEntry-Event 'TvheadendClient.Data.Dvr.IDvrEntry.Event')
  - [EventId](#P-TvheadendClient-Data-Dvr-IDvrEntry-EventId 'TvheadendClient.Data.Dvr.IDvrEntry.EventId')
  - [Start](#P-TvheadendClient-Data-Dvr-IDvrEntry-Start 'TvheadendClient.Data.Dvr.IDvrEntry.Start')
  - [State](#P-TvheadendClient-Data-Dvr-IDvrEntry-State 'TvheadendClient.Data.Dvr.IDvrEntry.State')
  - [Stop](#P-TvheadendClient-Data-Dvr-IDvrEntry-Stop 'TvheadendClient.Data.Dvr.IDvrEntry.Stop')
  - [Subtitle](#P-TvheadendClient-Data-Dvr-IDvrEntry-Subtitle 'TvheadendClient.Data.Dvr.IDvrEntry.Subtitle')
  - [Summary](#P-TvheadendClient-Data-Dvr-IDvrEntry-Summary 'TvheadendClient.Data.Dvr.IDvrEntry.Summary')
  - [TimeRecording](#P-TvheadendClient-Data-Dvr-IDvrEntry-TimeRecording 'TvheadendClient.Data.Dvr.IDvrEntry.TimeRecording')
  - [TimerecId](#P-TvheadendClient-Data-Dvr-IDvrEntry-TimerecId 'TvheadendClient.Data.Dvr.IDvrEntry.TimerecId')
  - [Title](#P-TvheadendClient-Data-Dvr-IDvrEntry-Title 'TvheadendClient.Data.Dvr.IDvrEntry.Title')
- [IDvrEntryStorage](#T-TvheadendClient-Data-Dvr-IDvrEntryStorage 'TvheadendClient.Data.Dvr.IDvrEntryStorage')
  - [ByChannel](#P-TvheadendClient-Data-Dvr-IDvrEntryStorage-ByChannel 'TvheadendClient.Data.Dvr.IDvrEntryStorage.ByChannel')
  - [ByEvent](#P-TvheadendClient-Data-Dvr-IDvrEntryStorage-ByEvent 'TvheadendClient.Data.Dvr.IDvrEntryStorage.ByEvent')
  - [TryAddDvrEntry(data,dvrEntryId)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryAddDvrEntry-TvheadendClient-Data-Dvr-AddDvrEntryData,System-Int64@- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryAddDvrEntry(TvheadendClient.Data.Dvr.AddDvrEntryData,System.Int64@)')
  - [TryCancel(id)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryCancel-System-Int64- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryCancel(System.Int64)')
  - [TryCancel(item)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryCancel-TvheadendClient-Data-Dvr-IDvrEntry- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryCancel(TvheadendClient.Data.Dvr.IDvrEntry)')
  - [TryDelete(id)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryDelete-System-Int64- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryDelete(System.Int64)')
  - [TryDelete(item)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryDelete-TvheadendClient-Data-Dvr-IDvrEntry- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryDelete(TvheadendClient.Data.Dvr.IDvrEntry)')
  - [TryRecordEvent(eventId,dvrEntryId)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent-System-Int64,System-Int64@- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryRecordEvent(System.Int64,System.Int64@)')
  - [TryRecordEvent(epgEvent,dvrEntryId)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent-TvheadendClient-Data-IEpgEvent,System-Int64@- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryRecordEvent(TvheadendClient.Data.IEpgEvent,System.Int64@)')
  - [TryStop(id)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryStop-System-Int64- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryStop(System.Int64)')
  - [TryStop(item)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryStop-TvheadendClient-Data-Dvr-IDvrEntry- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryStop(TvheadendClient.Data.Dvr.IDvrEntry)')
  - [TryUpdateDvrEntry(data)](#M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryUpdateDvrEntry-TvheadendClient-Data-Dvr-UpdateDvrEntryData- 'TvheadendClient.Data.Dvr.IDvrEntryStorage.TryUpdateDvrEntry(TvheadendClient.Data.Dvr.UpdateDvrEntryData)')
- [IEpgEvent](#T-TvheadendClient-Data-IEpgEvent 'TvheadendClient.Data.IEpgEvent')
  - [Channel](#P-TvheadendClient-Data-IEpgEvent-Channel 'TvheadendClient.Data.IEpgEvent.Channel')
  - [ChannelId](#P-TvheadendClient-Data-IEpgEvent-ChannelId 'TvheadendClient.Data.IEpgEvent.ChannelId')
  - [ContentType](#P-TvheadendClient-Data-IEpgEvent-ContentType 'TvheadendClient.Data.IEpgEvent.ContentType')
  - [ContentTypeId](#P-TvheadendClient-Data-IEpgEvent-ContentTypeId 'TvheadendClient.Data.IEpgEvent.ContentTypeId')
  - [Description](#P-TvheadendClient-Data-IEpgEvent-Description 'TvheadendClient.Data.IEpgEvent.Description')
  - [DvrEntries](#P-TvheadendClient-Data-IEpgEvent-DvrEntries 'TvheadendClient.Data.IEpgEvent.DvrEntries')
  - [Start](#P-TvheadendClient-Data-IEpgEvent-Start 'TvheadendClient.Data.IEpgEvent.Start')
  - [Stop](#P-TvheadendClient-Data-IEpgEvent-Stop 'TvheadendClient.Data.IEpgEvent.Stop')
  - [Summary](#P-TvheadendClient-Data-IEpgEvent-Summary 'TvheadendClient.Data.IEpgEvent.Summary')
  - [Title](#P-TvheadendClient-Data-IEpgEvent-Title 'TvheadendClient.Data.IEpgEvent.Title')
- [IEpgEventStorage](#T-TvheadendClient-Data-IEpgEventStorage 'TvheadendClient.Data.IEpgEventStorage')
  - [ByChannels](#P-TvheadendClient-Data-IEpgEventStorage-ByChannels 'TvheadendClient.Data.IEpgEventStorage.ByChannels')
- [IItems\`2](#T-TvheadendClient-Data-IItems`2 'TvheadendClient.Data.IItems`2')
- [ITag](#T-TvheadendClient-Data-ITag 'TvheadendClient.Data.ITag')
  - [Channels](#P-TvheadendClient-Data-ITag-Channels 'TvheadendClient.Data.ITag.Channels')
  - [Index](#P-TvheadendClient-Data-ITag-Index 'TvheadendClient.Data.ITag.Index')
  - [Name](#P-TvheadendClient-Data-ITag-Name 'TvheadendClient.Data.ITag.Name')
- [ITagStorage](#T-TvheadendClient-Data-ITagStorage 'TvheadendClient.Data.ITagStorage')
- [ITimeRecording](#T-TvheadendClient-Data-Dvr-ITimeRecording 'TvheadendClient.Data.Dvr.ITimeRecording')
  - [Channel](#P-TvheadendClient-Data-Dvr-ITimeRecording-Channel 'TvheadendClient.Data.Dvr.ITimeRecording.Channel')
  - [ChannelId](#P-TvheadendClient-Data-Dvr-ITimeRecording-ChannelId 'TvheadendClient.Data.Dvr.ITimeRecording.ChannelId')
  - [DaysOfWeek](#P-TvheadendClient-Data-Dvr-ITimeRecording-DaysOfWeek 'TvheadendClient.Data.Dvr.ITimeRecording.DaysOfWeek')
  - [Enabled](#P-TvheadendClient-Data-Dvr-ITimeRecording-Enabled 'TvheadendClient.Data.Dvr.ITimeRecording.Enabled')
  - [Name](#P-TvheadendClient-Data-Dvr-ITimeRecording-Name 'TvheadendClient.Data.Dvr.ITimeRecording.Name')
  - [Retention](#P-TvheadendClient-Data-Dvr-ITimeRecording-Retention 'TvheadendClient.Data.Dvr.ITimeRecording.Retention')
  - [Start](#P-TvheadendClient-Data-Dvr-ITimeRecording-Start 'TvheadendClient.Data.Dvr.ITimeRecording.Start')
  - [Stop](#P-TvheadendClient-Data-Dvr-ITimeRecording-Stop 'TvheadendClient.Data.Dvr.ITimeRecording.Stop')
  - [Title](#P-TvheadendClient-Data-Dvr-ITimeRecording-Title 'TvheadendClient.Data.Dvr.ITimeRecording.Title')
- [ITimeRecordingStorage](#T-TvheadendClient-Data-Dvr-ITimeRecordingStorage 'TvheadendClient.Data.Dvr.ITimeRecordingStorage')
- [ITvheadendData](#T-TvheadendClient-Data-ITvheadendData 'TvheadendClient.Data.ITvheadendData')
  - [AutoRecordings](#P-TvheadendClient-Data-ITvheadendData-AutoRecordings 'TvheadendClient.Data.ITvheadendData.AutoRecordings')
  - [Channels](#P-TvheadendClient-Data-ITvheadendData-Channels 'TvheadendClient.Data.ITvheadendData.Channels')
  - [ContentTypes](#P-TvheadendClient-Data-ITvheadendData-ContentTypes 'TvheadendClient.Data.ITvheadendData.ContentTypes')
  - [DvrEntries](#P-TvheadendClient-Data-ITvheadendData-DvrEntries 'TvheadendClient.Data.ITvheadendData.DvrEntries')
  - [Events](#P-TvheadendClient-Data-ITvheadendData-Events 'TvheadendClient.Data.ITvheadendData.Events')
  - [Ready](#P-TvheadendClient-Data-ITvheadendData-Ready 'TvheadendClient.Data.ITvheadendData.Ready')
  - [Tags](#P-TvheadendClient-Data-ITvheadendData-Tags 'TvheadendClient.Data.ITvheadendData.Tags')
  - [TimeRecordings](#P-TvheadendClient-Data-ITvheadendData-TimeRecordings 'TvheadendClient.Data.ITvheadendData.TimeRecordings')
- [ItemChangeEvent\`1](#T-TvheadendClient-Data-ItemChangeEvent`1 'TvheadendClient.Data.ItemChangeEvent`1')
  - [Item](#P-TvheadendClient-Data-ItemChangeEvent`1-Item 'TvheadendClient.Data.ItemChangeEvent`1.Item')
- [MessageBase](#T-TvheadendClient-Messages-MessageBase 'TvheadendClient.Messages.MessageBase')
  - [#ctor(method)](#M-TvheadendClient-Messages-MessageBase-#ctor-System-String- 'TvheadendClient.Messages.MessageBase.#ctor(System.String)')
- [NoAccessException](#T-TvheadendClient-Exceptions-NoAccessException 'TvheadendClient.Exceptions.NoAccessException')
- [UpdateDvrEntryData](#T-TvheadendClient-Data-Dvr-UpdateDvrEntryData 'TvheadendClient.Data.Dvr.UpdateDvrEntryData')
  - [#ctor(id)](#M-TvheadendClient-Data-Dvr-UpdateDvrEntryData-#ctor-System-Int64- 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.#ctor(System.Int64)')
  - [ChannelId](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-ChannelId 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.ChannelId')
  - [Description](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Description 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Description')
  - [Enabled](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Enabled 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Enabled')
  - [Id](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Id 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Id')
  - [Retention](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Retention 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Retention')
  - [Start](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Start 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Start')
  - [StartExtra](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-StartExtra 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.StartExtra')
  - [Stop](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Stop 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Stop')
  - [StopExtra](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-StopExtra 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.StopExtra')
  - [Subtitle](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Subtitle 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Subtitle')
  - [Title](#P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Title 'TvheadendClient.Data.Dvr.UpdateDvrEntryData.Title')

<a name='T-TvheadendClient-Data-Dvr-AddDvrEntryData'></a>
## AddDvrEntryData `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Request data for creating new DVR entry

<a name='M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-System-Int64-'></a>
### #ctor(eventId) `constructor`

##### Summary

Creates new Add recording data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Event id |

<a name='M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-System-Int64,System-DateTime,System-DateTime,System-String-'></a>
### #ctor(channelId,start,stop,title) `constructor`

##### Summary

Creates new Add recording data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| channelId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Id of channel |
| start | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | start of recording |
| stop | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | stop of recording |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | recording title |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | throws when title is not set |

<a name='M-TvheadendClient-Data-Dvr-AddDvrEntryData-#ctor-TvheadendClient-Data-IChannel,System-DateTime,System-DateTime,System-String-'></a>
### #ctor(channel,start,stop,title) `constructor`

##### Summary

Creates new Add recording data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| channel | [TvheadendClient.Data.IChannel](#T-TvheadendClient-Data-IChannel 'TvheadendClient.Data.IChannel') | Channel |
| start | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | start of recording |
| stop | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | stop of recording |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | recording title |

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-ChannelId'></a>
### ChannelId `property`

##### Summary

ChannelId

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Description'></a>
### Description `property`

##### Summary

Recording description

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Enabled'></a>
### Enabled `property`

##### Summary

Recording enabled

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-EventId'></a>
### EventId `property`

##### Summary

Event Id

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Priority'></a>
### Priority `property`

##### Summary

Priority

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Retention'></a>
### Retention `property`

##### Summary

Recording retention in days

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Start'></a>
### Start `property`

##### Summary

Start of recording

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-StartExtra'></a>
### StartExtra `property`

##### Summary

Extra time for recording start in minutes

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Stop'></a>
### Stop `property`

##### Summary

Stop of recording

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-StopExtra'></a>
### StopExtra `property`

##### Summary

Extra stop for recording stop in minutes

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Subtitle'></a>
### Subtitle `property`

##### Summary

Recording Subtitle

<a name='P-TvheadendClient-Data-Dvr-AddDvrEntryData-Title'></a>
### Title `property`

##### Summary

Recording Title

<a name='T-TvheadendClient-Client'></a>
## Client `type`

##### Namespace

TvheadendClient

##### Summary

Client for connecting to tvheadend server

<a name='M-TvheadendClient-Client-#ctor-TvheadendClient-ClientOptions-'></a>
### #ctor(options) `constructor`

##### Summary

Creates new client

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [TvheadendClient.ClientOptions](#T-TvheadendClient-ClientOptions 'TvheadendClient.ClientOptions') | connection options |

<a name='M-TvheadendClient-Client-#ctor-TvheadendClient-ClientOptions,Microsoft-Extensions-Logging-ILoggerFactory-'></a>
### #ctor(options,loggerFactory) `constructor`

##### Summary

Creates new client

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [TvheadendClient.ClientOptions](#T-TvheadendClient-ClientOptions 'TvheadendClient.ClientOptions') | connection options |
| loggerFactory | [Microsoft.Extensions.Logging.ILoggerFactory](#T-Microsoft-Extensions-Logging-ILoggerFactory 'Microsoft.Extensions.Logging.ILoggerFactory') | Logger factory instance |

<a name='P-TvheadendClient-Client-Connected'></a>
### Connected `property`

##### Summary

Shows if client is connected

<a name='P-TvheadendClient-Client-Data'></a>
### Data `property`

##### Summary

Data readed from server

<a name='M-TvheadendClient-Client-Connect'></a>
### Connect() `method`

##### Summary

Connect to server

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Client-Disconnect'></a>
### Disconnect() `method`

##### Summary

Disconnect from server

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Client-Dispose'></a>
### Dispose() `method`

##### Summary

[IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable')

##### Parameters

This method has no parameters.

<a name='T-TvheadendClient-ClientOptions'></a>
## ClientOptions `type`

##### Namespace

TvheadendClient

##### Summary

Oprtions for client - connection setting etc

<a name='M-TvheadendClient-ClientOptions-#ctor'></a>
### #ctor() `constructor`

##### Summary

Default constructor

##### Parameters

This constructor has no parameters.

<a name='P-TvheadendClient-ClientOptions-Culture'></a>
### Culture `property`

##### Summary

Culture for readind data from server

<a name='P-TvheadendClient-ClientOptions-Host'></a>
### Host `property`

##### Summary

Host - required

<a name='P-TvheadendClient-ClientOptions-Ipv6'></a>
### Ipv6 `property`

##### Summary

Flag to use ipv6 instead ipv4

<a name='P-TvheadendClient-ClientOptions-Password'></a>
### Password `property`

##### Summary

Password - needed when username is provided

<a name='P-TvheadendClient-ClientOptions-Port'></a>
### Port `property`

##### Summary

Port default 9982

<a name='P-TvheadendClient-ClientOptions-UserName'></a>
### UserName `property`

##### Summary

UserName - optiona

<a name='T-TvheadendClient-Data-DaysOfWeek'></a>
## DaysOfWeek `type`

##### Namespace

TvheadendClient.Data

##### Summary

Enum for days of week Multiple options can be specified using |

<a name='F-TvheadendClient-Data-DaysOfWeek-Everyday'></a>
### Everyday `constants`

##### Summary

Everyday

<a name='F-TvheadendClient-Data-DaysOfWeek-Friday'></a>
### Friday `constants`

##### Summary

Friday

<a name='F-TvheadendClient-Data-DaysOfWeek-Monday'></a>
### Monday `constants`

##### Summary

Monday

<a name='F-TvheadendClient-Data-DaysOfWeek-Saturday'></a>
### Saturday `constants`

##### Summary

Saturday

<a name='F-TvheadendClient-Data-DaysOfWeek-Sunday'></a>
### Sunday `constants`

##### Summary

Sunday

<a name='F-TvheadendClient-Data-DaysOfWeek-Thursday'></a>
### Thursday `constants`

##### Summary

Thursday

<a name='F-TvheadendClient-Data-DaysOfWeek-Tuesday'></a>
### Tuesday `constants`

##### Summary

Tuesday

<a name='F-TvheadendClient-Data-DaysOfWeek-Wednesday'></a>
### Wednesday `constants`

##### Summary

Wednesday

<a name='T-TvheadendClient-Messages-DynamicMessageItem'></a>
## DynamicMessageItem `type`

##### Namespace

TvheadendClient.Messages

##### Summary

Dynamic message item for comunicating with server

<a name='M-TvheadendClient-Messages-DynamicMessageItem-GetDynamicMemberNames'></a>
### GetDynamicMemberNames() `method`

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Messages-DynamicMessageItem-Get``1-System-String,``0-'></a>
### Get\`\`1(name,def) `method`

##### Summary

Get child value

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property name |
| def | [\`\`0](#T-``0 '``0') | default value |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | child type from server -  can be received only long?, string, byte[], DynamicMessageItem or array of this types |

<a name='M-TvheadendClient-Messages-DynamicMessageItem-Set-System-String,System-Object-'></a>
### Set(name,value) `method`

##### Summary

Set value  - to server can be send only long?, int?, string, byte[], DynamicMessageItem or array of this types

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | property name |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | value |

<a name='M-TvheadendClient-Messages-DynamicMessageItem-TryGetIndex-System-Dynamic-GetIndexBinder,System-Object[],System-Object@-'></a>
### TryGetIndex() `method`

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Messages-DynamicMessageItem-TryGetMember-System-Dynamic-GetMemberBinder,System-Object@-'></a>
### TryGetMember() `method`

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Messages-DynamicMessageItem-TrySetIndex-System-Dynamic-SetIndexBinder,System-Object[],System-Object-'></a>
### TrySetIndex() `method`

##### Parameters

This method has no parameters.

<a name='M-TvheadendClient-Messages-DynamicMessageItem-TrySetMember-System-Dynamic-SetMemberBinder,System-Object-'></a>
### TrySetMember() `method`

##### Parameters

This method has no parameters.

<a name='T-TvheadendClient-Data-EpgContentType'></a>
## EpgContentType `type`

##### Namespace

TvheadendClient.Data

##### Summary

List of EPG content types using RFC

<a name='P-TvheadendClient-Data-EpgContentType-ContentTypes'></a>
### ContentTypes `property`

##### Summary

Loaded content types for languages

<a name='P-TvheadendClient-Data-EpgContentType-DefaultContentTypes'></a>
### DefaultContentTypes `property`

##### Summary

Loaded content types for default language

<a name='P-TvheadendClient-Data-EpgContentType-Level1'></a>
### Level1 `property`

##### Summary

Epg level1 byte type

<a name='P-TvheadendClient-Data-EpgContentType-Level1Description'></a>
### Level1Description `property`

##### Summary

Level 1 description

<a name='P-TvheadendClient-Data-EpgContentType-Level2'></a>
### Level2 `property`

##### Summary

Epg level2 byte type

<a name='P-TvheadendClient-Data-EpgContentType-Level2Description'></a>
### Level2Description `property`

##### Summary

Level 2 description

<a name='P-TvheadendClient-Data-EpgContentType-Value'></a>
### Value `property`

##### Summary

Type value

<a name='T-TvheadendClient-Exceptions-HtspException'></a>
## HtspException `type`

##### Namespace

TvheadendClient.Exceptions

##### Summary

Exception raised when communicating with server

<a name='T-TvheadendClient-Exceptions-HtspMessageException'></a>
## HtspMessageException `type`

##### Namespace

TvheadendClient.Exceptions

##### Summary

Exception throwed when error serializing and deserializing message

<a name='T-TvheadendClient-Data-Dvr-IAutoRecordingEntry'></a>
## IAutoRecordingEntry `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Automatic recording based on epg data

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Channel'></a>
### Channel `property`

##### Summary

Channel

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-ChannelId'></a>
### ChannelId `property`

##### Summary

Channel id

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Enabled'></a>
### Enabled `property`

##### Summary

Enabled

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Fulltext'></a>
### Fulltext `property`

##### Summary

Fulltext enabled

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Name'></a>
### Name `property`

##### Summary

Autorecording name

<a name='P-TvheadendClient-Data-Dvr-IAutoRecordingEntry-Title'></a>
### Title `property`

##### Summary

Title for recording

<a name='T-TvheadendClient-Data-Dvr-IAutoRecordingStorage'></a>
## IAutoRecordingStorage `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Storage for automatic recordings

<a name='T-TvheadendClient-Data-IChannel'></a>
## IChannel `type`

##### Namespace

TvheadendClient.Data

##### Summary

Channel

<a name='P-TvheadendClient-Data-IChannel-Events'></a>
### Events `property`

##### Summary

Events

<a name='P-TvheadendClient-Data-IChannel-Icon'></a>
### Icon `property`

##### Summary

channel Icon

<a name='P-TvheadendClient-Data-IChannel-Name'></a>
### Name `property`

##### Summary

channel name

<a name='P-TvheadendClient-Data-IChannel-Number'></a>
### Number `property`

##### Summary

Channel number

<a name='P-TvheadendClient-Data-IChannel-NumberMinor'></a>
### NumberMinor `property`

##### Summary

Channel number minor

<a name='P-TvheadendClient-Data-IChannel-TagIds'></a>
### TagIds `property`

##### Summary

Channel tag Ids

<a name='P-TvheadendClient-Data-IChannel-Tags'></a>
### Tags `property`

##### Summary

Channel Tags

<a name='T-TvheadendClient-Data-IChannelStorage'></a>
## IChannelStorage `type`

##### Namespace

TvheadendClient.Data

##### Summary

Channels storage

<a name='T-TvheadendClient-Data-IDataItem'></a>
## IDataItem `type`

##### Namespace

TvheadendClient.Data

##### Summary

Tvheadend data item

<a name='T-TvheadendClient-Data-IDataItem`1'></a>
## IDataItem\`1 `type`

##### Namespace

TvheadendClient.Data

##### Summary

Tvheadend data item with id

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TId | type of Id |

<a name='P-TvheadendClient-Data-IDataItem`1-Id'></a>
### Id `property`

##### Summary

Id

<a name='T-TvheadendClient-Data-Dvr-IDvrConfiguration'></a>
## IDvrConfiguration `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Dvr configuration item

<a name='P-TvheadendClient-Data-Dvr-IDvrConfiguration-Comment'></a>
### Comment `property`

##### Summary

Comment

<a name='P-TvheadendClient-Data-Dvr-IDvrConfiguration-Name'></a>
### Name `property`

##### Summary

Dvr configuration item name

<a name='T-TvheadendClient-Data-Dvr-IDvrEntry'></a>
## IDvrEntry `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Dvr entry

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-AutoRecordingEntry'></a>
### AutoRecordingEntry `property`

##### Summary

Autorecording

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-AutorecordId'></a>
### AutorecordId `property`

##### Summary

AutorecordingId

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Channel'></a>
### Channel `property`

##### Summary

Channel

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-ChannelId'></a>
### ChannelId `property`

##### Summary

ChannelId

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Comment'></a>
### Comment `property`

##### Summary

Comment

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Description'></a>
### Description `property`

##### Summary

Description

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Enabled'></a>
### Enabled `property`

##### Summary

Enabled

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Event'></a>
### Event `property`

##### Summary

Event

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-EventId'></a>
### EventId `property`

##### Summary

EventId

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Start'></a>
### Start `property`

##### Summary

Start

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-State'></a>
### State `property`

##### Summary

State

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Stop'></a>
### Stop `property`

##### Summary

Stop

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Subtitle'></a>
### Subtitle `property`

##### Summary

Subtitle

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Summary'></a>
### Summary `property`

##### Summary

Summary

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-TimeRecording'></a>
### TimeRecording `property`

##### Summary

Time recording

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-TimerecId'></a>
### TimerecId `property`

##### Summary

Time recording Id

<a name='P-TvheadendClient-Data-Dvr-IDvrEntry-Title'></a>
### Title `property`

##### Summary

Title

<a name='T-TvheadendClient-Data-Dvr-IDvrEntryStorage'></a>
## IDvrEntryStorage `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Dvr entry storage.

<a name='P-TvheadendClient-Data-Dvr-IDvrEntryStorage-ByChannel'></a>
### ByChannel `property`

##### Summary

Dvr events indexed by channel id

<a name='P-TvheadendClient-Data-Dvr-IDvrEntryStorage-ByEvent'></a>
### ByEvent `property`

##### Summary

Dvr events indexed by event id

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryAddDvrEntry-TvheadendClient-Data-Dvr-AddDvrEntryData,System-Int64@-'></a>
### TryAddDvrEntry(data,dvrEntryId) `method`

##### Summary

Add new Dvr entry

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [TvheadendClient.Data.Dvr.AddDvrEntryData](#T-TvheadendClient-Data-Dvr-AddDvrEntryData 'TvheadendClient.Data.Dvr.AddDvrEntryData') | data for new dvr entry |
| dvrEntryId | [System.Int64@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64@ 'System.Int64@') | id of created dvr entry |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryCancel-System-Int64-'></a>
### TryCancel(id) `method`

##### Summary

Try cancel dvr entry by id (do not delete)

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | dvr entry id |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryCancel-TvheadendClient-Data-Dvr-IDvrEntry-'></a>
### TryCancel(item) `method`

##### Summary

Try cancel dvr entry by id (do not delete)

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TvheadendClient.Data.Dvr.IDvrEntry](#T-TvheadendClient-Data-Dvr-IDvrEntry 'TvheadendClient.Data.Dvr.IDvrEntry') | dvr entry from deleting |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryDelete-System-Int64-'></a>
### TryDelete(id) `method`

##### Summary

Try delete dvr entry by id

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | dvr entry id |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryDelete-TvheadendClient-Data-Dvr-IDvrEntry-'></a>
### TryDelete(item) `method`

##### Summary

Try delete dvr entry by id

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TvheadendClient.Data.Dvr.IDvrEntry](#T-TvheadendClient-Data-Dvr-IDvrEntry 'TvheadendClient.Data.Dvr.IDvrEntry') | dvr entry from deleting |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent-System-Int64,System-Int64@-'></a>
### TryRecordEvent(eventId,dvrEntryId) `method`

##### Summary

Try add event recording

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | event id |
| dvrEntryId | [System.Int64@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64@ 'System.Int64@') | id of created dvr entry |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent-TvheadendClient-Data-IEpgEvent,System-Int64@-'></a>
### TryRecordEvent(epgEvent,dvrEntryId) `method`

##### Summary

Try add event recording

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| epgEvent | [TvheadendClient.Data.IEpgEvent](#T-TvheadendClient-Data-IEpgEvent 'TvheadendClient.Data.IEpgEvent') | Epg event |
| dvrEntryId | [System.Int64@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64@ 'System.Int64@') | id of created dvr entry |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryStop-System-Int64-'></a>
### TryStop(id) `method`

##### Summary

Try stop recording (only when recording in progress)

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | dvr entry id |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryStop-TvheadendClient-Data-Dvr-IDvrEntry-'></a>
### TryStop(item) `method`

##### Summary

Try stop recording (only when recording in progress)

##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TvheadendClient.Data.Dvr.IDvrEntry](#T-TvheadendClient-Data-Dvr-IDvrEntry 'TvheadendClient.Data.Dvr.IDvrEntry') | dvr entry from deleting |

<a name='M-TvheadendClient-Data-Dvr-IDvrEntryStorage-TryUpdateDvrEntry-TvheadendClient-Data-Dvr-UpdateDvrEntryData-'></a>
### TryUpdateDvrEntry(data) `method`

##### Summary



##### Returns

true when success

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [TvheadendClient.Data.Dvr.UpdateDvrEntryData](#T-TvheadendClient-Data-Dvr-UpdateDvrEntryData 'TvheadendClient.Data.Dvr.UpdateDvrEntryData') | data for updating dvr entry |

<a name='T-TvheadendClient-Data-IEpgEvent'></a>
## IEpgEvent `type`

##### Namespace

TvheadendClient.Data

##### Summary

Epg event data

<a name='P-TvheadendClient-Data-IEpgEvent-Channel'></a>
### Channel `property`

##### Summary

Channel

<a name='P-TvheadendClient-Data-IEpgEvent-ChannelId'></a>
### ChannelId `property`

##### Summary

Channel id

<a name='P-TvheadendClient-Data-IEpgEvent-ContentType'></a>
### ContentType `property`

##### Summary

Content Type

<a name='P-TvheadendClient-Data-IEpgEvent-ContentTypeId'></a>
### ContentTypeId `property`

##### Summary

Content type Id

<a name='P-TvheadendClient-Data-IEpgEvent-Description'></a>
### Description `property`

##### Summary

Event description

<a name='P-TvheadendClient-Data-IEpgEvent-DvrEntries'></a>
### DvrEntries `property`

##### Summary

Related Dvr entries

<a name='P-TvheadendClient-Data-IEpgEvent-Start'></a>
### Start `property`

##### Summary

Event start

<a name='P-TvheadendClient-Data-IEpgEvent-Stop'></a>
### Stop `property`

##### Summary

Event stop

<a name='P-TvheadendClient-Data-IEpgEvent-Summary'></a>
### Summary `property`

##### Summary

Event summary

<a name='P-TvheadendClient-Data-IEpgEvent-Title'></a>
### Title `property`

##### Summary

Event title

<a name='T-TvheadendClient-Data-IEpgEventStorage'></a>
## IEpgEventStorage `type`

##### Namespace

TvheadendClient.Data

##### Summary

Epg event storage

<a name='P-TvheadendClient-Data-IEpgEventStorage-ByChannels'></a>
### ByChannels `property`

##### Summary

Events indexed by channels

<a name='T-TvheadendClient-Data-IItems`2'></a>
## IItems\`2 `type`

##### Namespace

TvheadendClient.Data

##### Summary

Items storage

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TInterfaceType |  |
| TIdType |  |

<a name='T-TvheadendClient-Data-ITag'></a>
## ITag `type`

##### Namespace

TvheadendClient.Data

##### Summary

Tag

<a name='P-TvheadendClient-Data-ITag-Channels'></a>
### Channels `property`

##### Summary

Channels

<a name='P-TvheadendClient-Data-ITag-Index'></a>
### Index `property`

##### Summary

Tag index

<a name='P-TvheadendClient-Data-ITag-Name'></a>
### Name `property`

##### Summary

Tag name

<a name='T-TvheadendClient-Data-ITagStorage'></a>
## ITagStorage `type`

##### Namespace

TvheadendClient.Data

##### Summary

Tag storage

<a name='T-TvheadendClient-Data-Dvr-ITimeRecording'></a>
## ITimeRecording `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Time recording entry

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Channel'></a>
### Channel `property`

##### Summary

Channel

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-ChannelId'></a>
### ChannelId `property`

##### Summary

Channel Id

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-DaysOfWeek'></a>
### DaysOfWeek `property`

##### Summary

Days of week (can contains multiple days)

##### Example

```
(DaysOfWeek &amp; DaysOfWeek.Tuesday) == DaysOfWeek.Tuesday
```

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Enabled'></a>
### Enabled `property`

##### Summary

Enabled

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Name'></a>
### Name `property`

##### Summary

Time recording name

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Retention'></a>
### Retention `property`

##### Summary

Recording retention in days

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Start'></a>
### Start `property`

##### Summary

Time recording start in munutes from midnight

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Stop'></a>
### Stop `property`

##### Summary

Time recording start in munutes from midnight

<a name='P-TvheadendClient-Data-Dvr-ITimeRecording-Title'></a>
### Title `property`

##### Summary

Recording title (naming of result)

<a name='T-TvheadendClient-Data-Dvr-ITimeRecordingStorage'></a>
## ITimeRecordingStorage `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Time recording storage

<a name='T-TvheadendClient-Data-ITvheadendData'></a>
## ITvheadendData `type`

##### Namespace

TvheadendClient.Data

##### Summary

TvheadendData data storage

<a name='P-TvheadendClient-Data-ITvheadendData-AutoRecordings'></a>
### AutoRecordings `property`

##### Summary

Auto recordings

<a name='P-TvheadendClient-Data-ITvheadendData-Channels'></a>
### Channels `property`

##### Summary

Channels

<a name='P-TvheadendClient-Data-ITvheadendData-ContentTypes'></a>
### ContentTypes `property`

##### Summary

Content Type storage

<a name='P-TvheadendClient-Data-ITvheadendData-DvrEntries'></a>
### DvrEntries `property`

##### Summary

DvrEntries

<a name='P-TvheadendClient-Data-ITvheadendData-Events'></a>
### Events `property`

##### Summary

Events

<a name='P-TvheadendClient-Data-ITvheadendData-Ready'></a>
### Ready `property`

##### Summary

All data loaded - true when initial load is done

<a name='P-TvheadendClient-Data-ITvheadendData-Tags'></a>
### Tags `property`

##### Summary

Tags

<a name='P-TvheadendClient-Data-ITvheadendData-TimeRecordings'></a>
### TimeRecordings `property`

##### Summary

Time recording entries

<a name='T-TvheadendClient-Data-ItemChangeEvent`1'></a>
## ItemChangeEvent\`1 `type`

##### Namespace

TvheadendClient.Data

##### Summary

Item changed data

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='P-TvheadendClient-Data-ItemChangeEvent`1-Item'></a>
### Item `property`

##### Summary

New event/ updated event (after updating) / deleted event data

<a name='T-TvheadendClient-Messages-MessageBase'></a>
## MessageBase `type`

##### Namespace

TvheadendClient.Messages

##### Summary

Message bese for sending to server

<a name='M-TvheadendClient-Messages-MessageBase-#ctor-System-String-'></a>
### #ctor(method) `constructor`

##### Summary

Create message with appropriate method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-TvheadendClient-Exceptions-NoAccessException'></a>
## NoAccessException `type`

##### Namespace

TvheadendClient.Exceptions

##### Summary

Exception raised when noacces is returned from server

<a name='T-TvheadendClient-Data-Dvr-UpdateDvrEntryData'></a>
## UpdateDvrEntryData `type`

##### Namespace

TvheadendClient.Data.Dvr

##### Summary

Data for updating Dvr Entry. When is property null, property is not changed

<a name='M-TvheadendClient-Data-Dvr-UpdateDvrEntryData-#ctor-System-Int64-'></a>
### #ctor(id) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Id of updated recording |

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-ChannelId'></a>
### ChannelId `property`

##### Summary

Channel Id

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Description'></a>
### Description `property`

##### Summary

Recording description

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Enabled'></a>
### Enabled `property`

##### Summary

Enabled

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Id'></a>
### Id `property`

##### Summary

Dvr entry Id

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Retention'></a>
### Retention `property`

##### Summary

Recording retention in days

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Start'></a>
### Start `property`

##### Summary

Recording start

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-StartExtra'></a>
### StartExtra `property`

##### Summary

Extra time before recording start

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Stop'></a>
### Stop `property`

##### Summary

Recording stop

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-StopExtra'></a>
### StopExtra `property`

##### Summary

Extra time after recording stop

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Subtitle'></a>
### Subtitle `property`

##### Summary

Recording subtitle

<a name='P-TvheadendClient-Data-Dvr-UpdateDvrEntryData-Title'></a>
### Title `property`

##### Summary

Recording title
