using Fixerr;

FixerEnvironment.ApiKey = "54aa583a39f77d6aff3348b9c4a1bd8b";
FixerEnvironment.IsPaidSubscription = false;

var fixer = new FixerClient(new HttpClient());
var latest = await fixer.GetLatestAsync("", "EURO, USD, JPY");
Console.WriteLine(latest?.TimeStamp);
