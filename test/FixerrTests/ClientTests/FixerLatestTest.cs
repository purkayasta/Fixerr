using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using FixerrTests.Helper;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class FixerLatestTest
    {
        private IFixerClient systemUnderTest;
        private Faker<LatestRateResponse> rateFaker;

        public FixerLatestTest()
        {
            FixerEnvironment.ApiKey = String.Empty;
            rateFaker = new Faker<LatestRateResponse>();
        }

        [Fact]
        public async Task ShouldThrowNullReferenceException_WhenApiKeyIsNotProvided()
        {
            FixerEnvironment.ApiKey = String.Empty;
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await systemUnderTest.GetLatestAsync());
        }

        [Fact]
        public async Task ShouldGiveSuccessResponse_WhenEverythingIsOk()
        {
            FixerEnvironment.ApiKey = "13";
            var fakeData = rateFaker.RuleFor(x => x.Success, true).Generate();
            var jsonData = JsonSerializer.Serialize(fakeData);

            HttpClient httpClient = FakeHttpClient.Create(jsonData);

            systemUnderTest = new FixerClient(httpClient);

            var expected = await systemUnderTest.GetLatestAsync("USD");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
