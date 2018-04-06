# Microsoft.AppCenter.Analytics.Metrics [![](https://raw.githubusercontent.com/pixel-cookers/built-with-badges/master/nuget/nuget-long.png)](https://www.nuget.org/packages/AppCenter.Analytics.Metrics)

This library contains enhancements to the `Microsoft.AppCenter.Analytics` package to provide additional metrics with direct logging to Visual Studio App Center. It provides an `AnalyticsMetrics` object implementing the `IAppCenterService` interface with the ability to track additional types of events. This allows you to use the measured information to enrich your analytics.

## Getting Started

This package can be installed as a **[nuget package](https://www.nuget.org/packages/AppCenter.Analytics.Metrics)**.

## Available Metrics

### TrackTimedEvent

Tracking the duration of an event such as a network request or some data processing task can be achieved using the `TrackTimedEvent()` method. 

#### App Center Event Properties

The following additional properties are exposed in the event sent to App Center:

| Property Name		| Property Value    									|
|----------------	|--------------------									|
| Start Time		| The start time of the event.							|
| End Time			| The end time of the event. 							|
| Duration			| The time interval between the start and end time. 	|

#### Example
```
using (AnalyticsMetrics.TrackTimedEvent("Network Request"))
{
	var client = new HttpClient();
	var response = await client.GetStringAsync("https://google.com");
	return response;
}
```