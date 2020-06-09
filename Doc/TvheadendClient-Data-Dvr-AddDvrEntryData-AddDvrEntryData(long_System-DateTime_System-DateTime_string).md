#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data.Dvr](./TvheadendClient-Data-Dvr.md 'TvheadendClient.Data.Dvr').[AddDvrEntryData](./TvheadendClient-Data-Dvr-AddDvrEntryData.md 'TvheadendClient.Data.Dvr.AddDvrEntryData')
## AddDvrEntryData(long, System.DateTime, System.DateTime, string) Constructor
Creates new Add recording data  
```csharp
public AddDvrEntryData(long channelId, System.DateTime start, System.DateTime stop, string title);
```
#### Parameters
<a name='TvheadendClient-Data-Dvr-AddDvrEntryData-AddDvrEntryData(long_System-DateTime_System-DateTime_string)-channelId'></a>
`channelId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Id of channel  
  
<a name='TvheadendClient-Data-Dvr-AddDvrEntryData-AddDvrEntryData(long_System-DateTime_System-DateTime_string)-start'></a>
`start` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
start of recording  
  
<a name='TvheadendClient-Data-Dvr-AddDvrEntryData-AddDvrEntryData(long_System-DateTime_System-DateTime_string)-stop'></a>
`stop` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
stop of recording  
  
<a name='TvheadendClient-Data-Dvr-AddDvrEntryData-AddDvrEntryData(long_System-DateTime_System-DateTime_string)-title'></a>
`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
recording title  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
throws when title is not set  
