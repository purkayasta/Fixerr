using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using FixerrTests.Helper;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class FluctuationTest
    {
        private IFixerClient systemUnderTest;
        private Faker<FluctuationResponse> fluctuationFaker;
        public FluctuationTest()
        {
            FixerEnvironment.ApiKey = String.Empty;
            this.fluctuationFaker = new Faker<FluctuationResponse>();
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("", ""));
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", ""));
        }

        [Fact]
        public async Task FluctuationTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            await Assert.ThrowsAsync<Exception>(async () => await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "20"));
        }

        [Fact]
        public async Task FluctuationTest_ShouldExecutedSuccessfully()
        {
            FixerEnvironment.ApiKey = "123";
            var fakeData = this.fluctuationFaker.RuleFor(x => x.Success, true).Generate();

            var jsonData = JsonSerializer.Serialize(fakeData);

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);

            var expected = await this.systemUnderTest.GetFluctuationAsync("2011-01-01", "2011-01-01");

            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
