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
    public class HistoricLatestTest
    {
        private IFixerClient systemUnderTest;
        private Faker<HistoricRateResponse> historicRateFaker;

        public HistoricLatestTest()
        {
            this.historicRateFaker = new Faker<HistoricRateResponse>();
        }

        [Fact]
        public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
        {
            FixerEnvironment.ApiKey = "13";
            var fakeData = this.historicRateFaker.RuleFor(x => x.Success, true).Generate();
            var jsonData = JsonSerializer.Serialize(fakeData);

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetHistoricRateAsync("2022-05-05");

            Assert.Equal(expected.Success, fakeData.Success);
        }

        [Fact]
        public async Task ShouldThrowException_WhenParamIsNotProvided()
        {
            FixerEnvironment.ApiKey = "13";
            var httpClient = FakeHttpClient.Create("");

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetHistoricRateAsync(""));
        }

        [Fact]
        public async Task ShouldThrowException_WhenSourceDateIsInInvalidState()
        {
            FixerEnvironment.ApiKey = "13";
            var httpClient = FakeHttpClient.Create("");

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetHistoricRateAsync("asda", "usd", "usd, bdt"));
        }
    }
}
