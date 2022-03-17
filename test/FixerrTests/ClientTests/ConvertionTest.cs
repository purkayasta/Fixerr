using System;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests
{
    public class ConvertionTest
    {
        private IFixerClient systemUnderTest;
        private Faker<CurrencyConvertResponse> currencyConvertResponseFaker;

        public ConvertionTest()
        {
            currencyConvertResponseFaker = new Faker<CurrencyConvertResponse>();
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenFromIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("", "", 0,null, "123"));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenToIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("as", "", 0, null, "132"));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenAmountIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<ArgumentException>(async () => await systemUnderTest.GetConvertionAsync("as", "a", -1, null,"123"));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenApiKeyIsNotProvidedAsync()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await systemUnderTest.GetConvertionAsync("as", "a", 0));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldThrowException_WhenHistoricDateIsInvalid()
        {
            var httpClient = ConfigureDefault.Get("");
            this.systemUnderTest = new FixerClient(httpClient);
            await Assert.ThrowsAsync<Exception>(async () => await systemUnderTest.GetConvertionAsync("as", "a", 0, "123", "123"));
        }

        [Fact]
        public async Task GetConvertionAsync_ShouldExecute_WhenEverythingIsOkay()
        {
            var fakeData = currencyConvertResponseFaker.RuleFor(x => x.Success, true).Generate();
            var httpClient = ConfigureDefault.Get(fakeData);

            this.systemUnderTest = new FixerClient(httpClient);
            var expected = await this.systemUnderTest.GetConvertionAsync("as", "as", 0, null, "123");
            Assert.Equal(expected.Success, fakeData.Success);
        }
    }
}
