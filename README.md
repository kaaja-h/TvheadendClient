# TvheadendClient
Client library for connecting to tvheadend. Reads EPG and recording data

## Connecting
```c#
var options = new ClientOptions(){
    Host = "192.168.1.5", //required
    Port = 9982, //default 9985
    UserName = "me", //optional
    Password = "myPassword" //optional
}
var loggerFactory = LoggerFactory.Create(builder => );
var client = new Client(options, loggerFactory);
client.Connect();
```
After connecting client will start receiving data from server (EPG, recordings, ...)

## Reading data

All avaiable data are stored on `client.Data` using `ITvheadendData`
```c#
    public interface ITvheadendData
    {
        ITagStorage Tags { get; } 
        IChannelStorage Channels { get; }
        IEpgEventStorage Events { get; }
        IAutoRecordStorage AutoRecords { get; }
        IDvrEntryStorage DvrEntries { get; }
        event EventHandler LoadComplete;
        bool Ready { get; }
        IReadOnlyCollection<string> ContentTypes { get; }
    }
```
After reading all data event LoadComplete is fired.
All data are stored on appropriate Storage in dictionary using ids.
```c#
///example reading Channels
var allChannels = client.Data.Channels.Items.Values;
///read epgEvents for Channel
var events = client.Data.Events.ByChannels[channelId];
```
When are data changed events are fired
```c#
//listen event
client.Data.Channels.ItemAdded += (sender, eventData) => { ...};

```

## TODO
1. Improve storing data from message do data object
2. Prepare methods for modifiing recordings and autorecordings
3. Fix bugs


