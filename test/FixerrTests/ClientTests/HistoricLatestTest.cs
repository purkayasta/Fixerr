using System;
using System.IO;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests;

public class HistoricLatestTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<HistoricRate> historicRateFaker;

    public HistoricLatestTest()
    {
        this.historicRateFaker = new Faker<HistoricRate>();
    }

    [Fact]
    public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
    {
        var fakeData = this.historicRateFaker.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        var expected = await this.systemUnderTest.GetHistoricRateAsync("2022-05-05", apiKey: "123");
        Assert.Equal(expected.Success, fakeData.Success);
    }

    [Fact]
    public async Task ShouldThrowException_WhenParamIsNotProvided()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetHistoricRateAsync("", apiKey: "123"));
    }

    [Fact]
    public async Task ShouldThrowException_WhenSourceDateIsInInvalidState()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        await Assert.ThrowsAsync<InvalidDataException>(async () => await this.systemUnderTest.GetHistoricRateAsync("asda", "usd", "usd, bdt", apiKey: "123"));
    }
}
