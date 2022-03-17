using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class FluctuationTest
    {
        private IFixerClient systemUnderTest;
        private Faker<FluctuationResponse> fluctuationFaker;
        public FluctuationTest()
        {
            this.fluctuationFaker = new Faker<FluctuationResponse>();
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("", "", null, "123"));
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "", null, null, "132"));
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "20", apiKey: "123"));
        }

        [Fact]
        public async Task FluctuationTest_ShouldExecutedSuccessfully()
        {
            var fakeData = this.fluctuationFaker.RuleFor(x => x.Success, true).Generate();

            var httpClient = ConfigureDefault.Get(fakeData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "2011-01-01", apiKey: "123");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
