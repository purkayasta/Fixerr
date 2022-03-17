using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class SymbolLatestTest
    {
        private IFixerClient systemUnderTest;
        private Faker<SymbolResponse> symbolResponseFakeModel;

        public SymbolLatestTest()
        {
            this.symbolResponseFakeModel = new Faker<SymbolResponse>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceException_WhenApiKeyIsNotProvided()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await this.systemUnderTest.GetSymbolAsync());
        }

        [Fact]
        public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
        {
            var fakeData = this.symbolResponseFakeModel.RuleFor(x => x.Success, true).Generate();
            var httpClient = ConfigureDefault.Get(fakeData);
            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetSymbolAsync(apiKey: "123");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
