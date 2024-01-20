using Fixerr;
using Fixerr.Installer;

IFixerClient client = FixerFactory.CreateFixerClient(new HttpClient(), "");

var rates = await client.GetLatestRateAsync("", "");