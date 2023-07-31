using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests;

public class FixerLatestTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<LatestRate> rateFaker;

    public FixerLatestTest()
    {
        rateFaker = new Faker<LatestRate>();
    }


    [Fact]
    public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
    {
        var fakeData = rateFaker.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));

        var expected = await systemUnderTest.GetLatestRateAsync("USD", apiKey: "123");

        Assert.Equal(expected.Success, fakeData.Success);
    }
}
