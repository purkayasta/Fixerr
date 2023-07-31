using Fixerr;
using Fixerr.Configurations;
using Fixerr.Installer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
