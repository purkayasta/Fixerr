using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
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
            var fakeData = this.historicRateFaker.RuleFor(x => x.Success, true).Generate();
            var httpClient = ConfigureDefault.Get(fakeData);
            this.systemUnderTest = new FixerClient(httpClient);
            var expected = await this.systemUnderTest.GetHistoricRateAsync("2022-05-05", apiKey: "123");
            Assert.Equal(expected.Success, fakeData.Success);
        }

        [Fact]
        public async Task ShouldThrowException_WhenParamIsNotProvided()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetHistoricRateAsync("", apiKey: "123"));
        }

        [Fact]
        public async Task ShouldThrowException_WhenSourceDateIsInInvalidState()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetHistoricRateAsync("asda", "usd", "usd, bdt", apiKey: "123"));
        }
    }
}
