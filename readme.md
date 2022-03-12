# Fixerr - A minimal c# client for [Fixer.io](https://fixer.io/)

## Usage:
Requirements:
- API Key

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
- Set the api key as string and paid subscription as boolean in ```FixerEnvironment``` class.


## F.A.Q:
If anything happens make sure to report using the github issues. Thanks!



## Api Cover
- [x] Latest Endpoint
- [x] Symbol Endpoint
- [x] Historic Endpoint
- [x] Convert Endpoint
- [x] TimeSeries Endpoint
- [x] Fluctuation Endpoint


## Overall Api Status
- [x] Access Key Configuration with and without DI.
- [ ] Test Case for every endpoint