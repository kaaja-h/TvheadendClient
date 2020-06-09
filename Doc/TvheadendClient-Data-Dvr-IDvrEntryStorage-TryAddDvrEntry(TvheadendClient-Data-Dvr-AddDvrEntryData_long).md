#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data.Dvr](./TvheadendClient-Data-Dvr.md 'TvheadendClient.Data.Dvr').[IDvrEntryStorage](./TvheadendClient-Data-Dvr-IDvrEntryStorage.md 'TvheadendClient.Data.Dvr.IDvrEntryStorage')
## IDvrEntryStorage.TryAddDvrEntry(TvheadendClient.Data.Dvr.AddDvrEntryData, long) Method
Add new Dvr entry  
```csharp
bool TryAddDvrEntry(TvheadendClient.Data.Dvr.AddDvrEntryData data, out long dvrEntryId);
```
#### Parameters
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryAddDvrEntry(TvheadendClient-Data-Dvr-AddDvrEntryData_long)-data'></a>
`data` [AddDvrEntryData](./TvheadendClient-Data-Dvr-AddDvrEntryData.md 'TvheadendClient.Data.Dvr.AddDvrEntryData')  
data for new dvr entry  
  
<a name='TvheadendClient-Data-Dvr-IDvrEntryStorage-TryAddDvrEntry(TvheadendClient-Data-Dvr-AddDvrEntryData_long)-dvrEntryId'></a>
`dvrEntryId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
id of created dvr entry  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true when success  
