#### [TvheadendClient](./index.md 'index')
### [TvheadendClient.Data.Dvr](./TvheadendClient-Data-Dvr.md 'TvheadendClient.Data.Dvr').[ITimeRecording](./TvheadendClient-Data-Dvr-ITimeRecording.md 'TvheadendClient.Data.Dvr.ITimeRecording')
## ITimeRecording.DaysOfWeek Property
Days of week (can contains multiple days)  
```csharp
TvheadendClient.Data.DaysOfWeek DaysOfWeek { get; }
```
#### Property Value
[DaysOfWeek](./TvheadendClient-Data-DaysOfWeek.md 'TvheadendClient.Data.DaysOfWeek')  
### Example
```

            (DaysOfWeek & DaysOfWeek.Tuesday) == DaysOfWeek.Tuesday
            
```  
