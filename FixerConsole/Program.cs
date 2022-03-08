using FixSharp;

var fixer = new FixSharper(new HttpClient());
var latest = await fixer.GetLatestAsync("bdt");