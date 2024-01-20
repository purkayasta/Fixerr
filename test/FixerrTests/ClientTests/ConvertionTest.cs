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
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await systemUnderTest.GetCurrencyConverterAsync("", "", 0, null, ""));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenToIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await systemUnderTest.GetCurrencyConverterAsync("as", "", 0, null, ""));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenAmountIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await systemUnderTest.GetCurrencyConverterAsync("as", "a", -1, null, ""));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenApiKeyIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        await Assert.ThrowsAsync<NullReferenceException>(async () =>
            await systemUnderTest.GetCurrencyConverterAsync("as", "a", 0, apiKey: ""));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldThrowException_WhenHistoricDateIsInvalid()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        await Assert.ThrowsAsync<Exception>(async () =>
            await systemUnderTest.GetCurrencyConverterAsync("as", "a", 0, "123", ""));
    }

    [Fact]
    public async Task GetConvertionAsync_ShouldExecute_WhenEverythingIsOkay()
    {
        var fakeData = currencyConvertResponseFaker.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));
        var expected = await this.systemUnderTest.GetCurrencyConverterAsync("as", "as", 0, null, "");
        Assert.Equal(expected.Success, fakeData.Success);
    }
}