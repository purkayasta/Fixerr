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
    public class TimeSeriesTest
    {
        private IFixerClient systemUnderTest;
        private Faker<TimeSeriesResponse> timeSeriesFaker;

        public TimeSeriesTest()
        {
            FixerEnvironment.ApiKey = String.Empty;
            this.timeSeriesFaker = new Faker<TimeSeriesResponse>();
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetTimeSeriesAsync("", ""));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", ""));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "20"));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldExecutedSuccessfully()
        {
            FixerEnvironment.ApiKey = "123";
            var fakeData = this.timeSeriesFaker.RuleFor(x => x.Success, true).Generate();

            var jsonData = JsonSerializer.Serialize(fakeData);

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "2011-01-01");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
