using System;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using FixerrTests.Helper;
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
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await this.systemUnderTest.GetSymbolAsync());
        }

        [Fact]
        public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
        {
            FixerEnvironment.ApiKey = "13";
            var fakeData = this.symbolResponseFakeModel.RuleFor(x => x.Success, true).Generate();
            var jsonData = JsonSerializer.Serialize(fakeData);

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetSymbolAsync();

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
