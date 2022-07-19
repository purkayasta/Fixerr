using Fixerr;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IFixerClient client = new FixerClient(new HttpClient(), "");

var rates = await client.GetLatestRateAsync("", "");