# Fixerr - An easy, minimal c# client for [Fixer.io](https://fixer.io/)
## Give it a star if you like the project. 👏 🌠 🌟

Fixer is a popular freemium currency conversion site. Fixerr can help you to transform your currency more faster 😋

![Nuget](https://img.shields.io/nuget/v/FixerClient)
![Nuget](https://img.shields.io/nuget/dt/FixerClient?style=plastic)
![Nuget](https://img.shields.io/github/repo-size/purkayasta/Fixerr?style=social)
![Nuget](https://img.shields.io/github/last-commit/purkayasta/fixerr?style=flat-square)

[Nuget](https://www.nuget.org/packages/FixerClient/)

## Usage:
### Required Properties:
- ```ApiKey```
- ```IsPaidSubscription``` (If you bought the non free key and want to use https, you may want to set it to true)

## With out any dependency injection
``` c#

var apiKey = "";
IFixerClient fixer = FixerFactory.CreateFixerClient(new HttpClient(), apiKey);
var latest = await fixer.GetFluctuationAsync("2012-05-01", "2012-05-25");
Console.WriteLine(latest?.Rates);
```

## With Microsoft DI
```c#
var apiKey = "";
builder.Services.AddFixer(apiKey);
```

If you chose to go with DI approach then after service registration, you will get a `IFixerClient` that you can access all your requested method.
```c# Injestion With DI
private readonly IFixerClient _fixerClient;

public YourFunction(IFixerClient fixerClient) => _fixerClient = fixerClient;

public void CallMethod() {
    var latest = await _fixerClient.GetFluctuationAsync("2012-05-01", "2012-05-25");
    // now do whatever 😋
}

```

## F.A.Q:
- There is also a optional apiKey parameter is added to every method if you need to access different method with different api key. 🎉
- If anything happens make sure to report using the github issues. Thanks!

## Api Cover
- [x] Latest Endpoint
- [x] Symbol Endpoint
- [x] Historic Endpoint
- [x] Convert Endpoint
- [x] TimeSeries Endpoint
- [x] Fluctuation Endpoint
