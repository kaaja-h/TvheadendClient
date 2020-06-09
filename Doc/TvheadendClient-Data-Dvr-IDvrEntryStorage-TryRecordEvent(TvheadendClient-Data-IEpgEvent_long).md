#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data.Dvr](./TvheadendClient-Data-Dvr.md 'TvheadendClient.Data.Dvr').[IDvrEntryStorage](./TvheadendClient-Data-Dvr-IDvrEntryStorage.md 'TvheadendClient.Data.Dvr.IDvrEntryStorage')
## IDvrEntryStorage.TryRecordEvent(TvheadendClient.Data.IEpgEvent, long) Method
Try add event recording  
```csharp
bool TryRecordEvent(TvheadendClient.Data.IEpgEvent epgEvent, out long dvrEntryId);
```
#### Parameters
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent(TvheadendClient-Data-IEpgEvent_long)-epgEvent'></a>
`epgEvent` [IEpgEvent](./TvheadendClient-Data-IEpgEvent.md 'TvheadendClient.Data.IEpgEvent')  
Epg event  
  
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryRecordEvent(TvheadendClient-Data-IEpgEvent_long)-dvrEntryId'></a>
`dvrEntryId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
id of created dvr entry  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true when success  
