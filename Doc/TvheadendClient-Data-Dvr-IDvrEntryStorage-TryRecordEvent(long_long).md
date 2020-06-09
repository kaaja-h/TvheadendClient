#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data.Dvr](./TvheadendClient-Data-Dvr.md 'TvheadendClient.Data.Dvr').[IDvrEntryStorage](./TvheadendClient-Data-Dvr-IDvrEntryStorage.md 'TvheadendClient.Data.Dvr.IDvrEntryStorage')
## IDvrEntryStorage.TryRecordEvent(long, long) Method
Try add event recording  
```csharp
bool TryRecordEvent(long eventId, out long dvrEntryId);
```
#### Parameters
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent(long_long)-eventId'></a>
`eventId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
event id  
  
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent(long_long)-dvrEntryId'></a>
`dvrEntryId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
id of created dvr entry  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true when success  
