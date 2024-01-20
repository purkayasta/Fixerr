using Fixerr.Installer;
using Fixerr;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFixer(string.Empty);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.MapGet("/currencyrate", async (string from, string to, int amount, IFixerClient fixerClient) =>
{
    return await fixerClient.GetCurrencyConverterAsync(from, to, amount);
})
.WithName("GetCurrencyRate");

app.Run();
