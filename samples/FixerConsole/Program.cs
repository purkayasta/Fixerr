using Fixerr;

FixerEnvironment.ApiKey = "";
FixerEnvironment.IsPaidSubscription = false;

var fixer = new FixerClient(new HttpClient());
var latest = await fixer.GetFluctuationAsync("2012-05-01", "2012-05-25");
Console.WriteLine(latest?.Rates);