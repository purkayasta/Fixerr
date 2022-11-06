using System;
using System.IO;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests;

public class FluctuationTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<Fluctuation> fluctuationFaker;
    public FluctuationTest()
    {
        this.fluctuationFaker = new Faker<Fluctuation>();
    }

    [Fact]
    public async Task FluctuationTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("", "", null, "123"));
    }

    [Fact]
    public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "", null, null, "132"));
    }

    [Fact]
    public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        await Assert.ThrowsAsync<InvalidDataException>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "20", apiKey: "123"));
    }

    [Fact]
    public async Task FluctuationTest_ShouldExecutedSuccessfully()
    {
        var fakeData = this.fluctuationFaker.RuleFor(x => x.Success, true).Generate();

        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        var expected = await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "2011-01-01", apiKey: "123");

        Assert.Equal(expected.Success, fakeData.Success);
    }
}
