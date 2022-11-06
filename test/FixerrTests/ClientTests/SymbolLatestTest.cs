using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests;

public class SymbolLatestTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<Symbol> symbolResponseFakeModel;

    public SymbolLatestTest()
    {
        this.symbolResponseFakeModel = new Faker<Symbol>();
    }

    [Fact]
    public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
    {
        var fakeData = this.symbolResponseFakeModel.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""), ConfigureDefault.GetFixerIOptions());

        var expected = await this.systemUnderTest.GetSymbolAsync(apiKey: "123");

        Assert.Equal(expected.Success, fakeData.Success);
    }
}
