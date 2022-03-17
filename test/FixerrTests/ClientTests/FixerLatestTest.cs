using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class FixerLatestTest
    {
        private IFixerClient systemUnderTest;
        private readonly Faker<LatestRateResponse> rateFaker;

        public FixerLatestTest()
        {
            rateFaker = new Faker<LatestRateResponse>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceException_WhenApiKeyIsNotProvided()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await systemUnderTest.GetLatestAsync());
        }

        [Fact]
        public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
        {
           
            var fakeData = rateFaker.RuleFor(x => x.Success, true).Generate();

            var httpClient = ConfigureDefault.Get(fakeData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await systemUnderTest.GetLatestAsync("USD", apiKey: "123");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
