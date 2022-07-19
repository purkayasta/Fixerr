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

## Console Application Demo:
``` c#

var apiKey = "";
var fixer = new FixerClient(new HttpClient(), apiKey);
var latest = await fixer.GetFluctuationAsync("2012-05-01", "2012-05-25");
Console.WriteLine(latest?.Rates);
```

## Web Api
```c#
builder.Services.AddFixer();
```

and in the controller section:
```c#
private readonly IFixerClient _fixerClient;

public FixerController(IFixerClient fixerClient)
{
    _fixerClient = fixerClient;
}

[HttpGet]
public async Task<IActionResult> Get()
{
    var response = await _fixerClient.GetLatestAsync();
    return Ok(response);
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
