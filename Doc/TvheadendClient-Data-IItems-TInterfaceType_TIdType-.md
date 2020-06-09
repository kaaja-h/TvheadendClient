#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data](./TvheadendClient-Data.md 'TvheadendClient.Data')
## IItems&lt;TInterfaceType,TIdType&gt; Interface
Items storage  
```csharp
public interface IItems<TInterfaceType,TIdType> :
IReadOnlyDictionary<TIdType, TInterfaceType>,
IEnumerable<KeyValuePair<TIdType, TInterfaceType>>,
IEnumerable,
IReadOnlyCollection<KeyValuePair<TIdType, TInterfaceType>>
```
Derived  
&#8627; [IAutoRecordingStorage](./TvheadendClient-Data-Dvr-IAutoRecordingStorage.md 'TvheadendClient.Data.Dvr.IAutoRecordingStorage')  
&#8627; [IDvrEntryStorage](./TvheadendClient-Data-Dvr-IDvrEntryStorage.md 'TvheadendClient.Data.Dvr.IDvrEntryStorage')  
&#8627; [ITimeRecordingStorage](./TvheadendClient-Data-Dvr-ITimeRecordingStorage.md 'TvheadendClient.Data.Dvr.ITimeRecordingStorage')  
&#8627; [IEpgEventStorage](./TvheadendClient-Data-IEpgEventStorage.md 'TvheadendClient.Data.IEpgEventStorage')  
&#8627; [IChannelStorage](./TvheadendClient-Data-IChannelStorage.md 'TvheadendClient.Data.IChannelStorage')  
&#8627; [ITagStorage](./TvheadendClient-Data-ITagStorage.md 'TvheadendClient.Data.ITagStorage')  

Implements [System.Collections.Generic.IReadOnlyDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TIdType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TIdType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TIdType')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2')[TInterfaceType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TInterfaceType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TInterfaceType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2 'System.Collections.Generic.IReadOnlyDictionary`2'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TIdType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TIdType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TIdType')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInterfaceType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TInterfaceType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TInterfaceType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TIdType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TIdType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TIdType')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInterfaceType](#TvheadendClient-Data-IItems-TInterfaceType_TIdType--TInterfaceType 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.TInterfaceType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')  
#### Type parameters
<a name='TvheadendClient-Data-IItems-TInterfaceType_TIdType--TInterfaceType'></a>
`TInterfaceType`  
  
  
<a name='TvheadendClient-Data-IItems-TInterfaceType_TIdType--TIdType'></a>
`TIdType`  
  
  
### Events
- [ItemAdded](./TvheadendClient-Data-IItems-TInterfaceType_TIdType--ItemAdded.md 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.ItemAdded')
- [ItemDeleted](./TvheadendClient-Data-IItems-TInterfaceType_TIdType--ItemDeleted.md 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.ItemDeleted')
- [ItemChanged](./TvheadendClient-Data-IItems-TInterfaceType_TIdType--ItemChanged.md 'TvheadendClient.Data.IItems&lt;TInterfaceType,TIdType&gt;.ItemChanged')
