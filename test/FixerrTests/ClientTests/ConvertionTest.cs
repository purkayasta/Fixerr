using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests;

public class ConvertionTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<CurrencyConverter> currencyConvertResponseFaker;

    public ConvertionTest()
    {
        currencyConvertResponseFaker = new Faker<CurrencyConverter>();
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenFromIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await systemUnderTest.GetCurrencyConverterAsync("", "", 0, null, "123"));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenToIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetCurrencyConverterAsync("as", "", 0, null, "132"));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenAmountIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetCurrencyConverterAsync("as", "a", -1, null, "123"));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenApiKeyIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<NullReferenceException>(async () => await systemUnderTest.GetCurrencyConverterAsync("as", "a", 0));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenHistoricDateIsInvalid()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<Exception>(async () => await systemUnderTest.GetCurrencyConverterAsync("as", "a", 0, "123", "123"));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldExecute_WhenEverythingIsOkay()
    {
        var fakeData = currencyConvertResponseFaker.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        var expected = await this.systemUnderTest.GetCurrencyConverterAsync("as", "as", 0, null, "123");
        Assert.Equal(expected.Success, fakeData.Success);
    }
}
