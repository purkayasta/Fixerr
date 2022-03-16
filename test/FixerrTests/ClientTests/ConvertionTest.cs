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
    public class ConvertionTest
    {
        private IFixerClient systemUnderTest;
        private Faker<CurrencyConvertResponse> currencyConvertResponseFaker;

        public ConvertionTest()
        {
            FixerEnvironment.ApiKey = String.Empty;
            currencyConvertResponseFaker = new Faker<CurrencyConvertResponse>();
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenFromIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("", "", 0));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenToIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("as", "", 0));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenAmountIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("as", "a", -1));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenApiKeyIsNotProvidedAsync()
        {
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await systemUnderTest.GetConvertionAsync("as", "a", 0));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenHistoricDateIsInvalid()
        {
            FixerEnvironment.ApiKey = "123";
            var jsonData = JsonSerializer.Serialize("");

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<Exception>(async () => await systemUnderTest.GetConvertionAsync("as", "a", 0, "12"));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldExecute_WhenEverythingIsOkay()
        {
            FixerEnvironment.ApiKey = "123";

            var fakeData = currencyConvertResponseFaker.RuleFor(x => x.Success, true).Generate();

            var jsonData = JsonSerializer.Serialize(fakeData);

            var httpClient = FakeHttpClient.Create(jsonData);

            this.systemUnderTest = new FixerClient(httpClient);
            var expected = await this.systemUnderTest.GetConvertionAsync("as", "as", 0);
            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
