using Fixerr;

FixerEnvironment.ApiKey = "54aa583a39f77d6aff3348b9c4a1bd8b";
FixerEnvironment.IsPaidSubscription = false;

var fixer = new FixerClient(new HttpClient());
var latest = await fixer.GetFluctuationAsync("2012-05-01", "2012-05-25");
Console.WriteLine(latest?.Rates);
