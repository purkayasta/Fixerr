using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class TimeSeriesTest
    {
        private IFixerClient systemUnderTest;
        private Faker<TimeSeriesResponse> timeSeriesFaker;

        public TimeSeriesTest()
        {
            this.timeSeriesFaker = new Faker<TimeSeriesResponse>();
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetTimeSeriesAsync("", "", apiKey: "123"));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "", apiKey: "123"));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "20", apiKey: "123"));
        }

        [Fact]
        public async Task TimeSeriesTest_ShouldExecutedSuccessfully()
        {
            var fakeData = this.timeSeriesFaker.RuleFor(x => x.Success, true).Generate();
            var httpClient = ConfigureDefault.Get(fakeData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "2011-01-01", apiKey: "123");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
