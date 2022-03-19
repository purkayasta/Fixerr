# Fixerr - An easy, minimal c# client for [Fixer.io](https://fixer.io/)

Fixer is a popular freemium currency conversion site. Fixerr can help you to transform your currency more faster 😋

![Nuget](https://img.shields.io/nuget/v/FixerClient)
![Nuget](https://img.shields.io/nuget/dt/FixerClient?style=plastic)

[Nuget](https://www.nuget.org/packages/FixerClient/)

## Usage:

### Requirements:
- API Key

### Library Required Properties:
- ```FixerEnvironment.ApiKey```
- ```FixerEnvironment.IsPaidSubscription``` (If you bought the non free key and want to use https, you may want to set it to true)

## Console Application Demo:
``` c#
FixerEnvironment.ApiKey = "{your_api_key}";
FixerEnvironment.IsPaidSubscription = false;

var fixer = new FixerClient(new HttpClient());
var latest = await fixer.GetFluctuationAsync("2012-05-01", "2012-05-25");
Console.WriteLine(latest?.Rates);
```

## Web Api
```c#
builder.Services.AddHttpClient();
FixerEnvironment.ApiKey = "{your_api_key}";
FixerEnvironment.IsPaidSubscription = true;
builder.Services.AddScoped<IFixerClient, FixerClient>();
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

## Best Practics:
- Make sure you use DI to inject HTTP Client. We prefer you will provide a Good HTTP Client instance.
- Set the ```ApiKey``` as string and paid subscription ```IsPaidSubscription``` as true/false in ```FixerEnvironment``` class.
- If you have different api keys for different methods then you don't need to set ```ApiKey``` into the ```FixerEnvirnoment```, you will have to pass the api key as a parameter
whenever you call any endpoints.


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
