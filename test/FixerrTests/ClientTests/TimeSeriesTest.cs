using System;
using System.IO;
using System.Threading.Tasks;
using Bogus;
using Fixerr;
using Fixerr.Models;
using Xunit;

namespace FixerrTests.ClientTests;

public class TimeSeriesTest
{
    private IFixerClient systemUnderTest;
    private readonly Faker<TimeSeries> timeSeriesFaker;

    public TimeSeriesTest() => timeSeriesFaker = new Faker<TimeSeries>();

    [Fact]
    public async Task TimeSeriesTest_ShouldThrowExceptionWhen_StartDateIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));

        await Assert.ThrowsAsync<ArgumentNullException>(async ()
            => await this.systemUnderTest.GetTimeSeriesAsync("", "", apiKey: "123"));
    }

    [Fact]
    public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotProvidedAsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));

        await Assert.ThrowsAsync<ArgumentNullException>(async ()
            => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "", apiKey: "123"));
    }

    [Fact]
    public async Task TimeSeriesTest_ShouldThrowExceptionWhen_EndDateIsNotValidsync()
    {
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));

        await Assert.ThrowsAsync<InvalidDataException>(async ()
            => await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "20", apiKey: "123"));
    }

    [Fact]
    public async Task TimeSeriesTest_ShouldExecutedSuccessfully()
    {
        var fakeData = timeSeriesFaker.RuleFor(x => x.Success, true).Generate();
        this.systemUnderTest = new FixerClient(ConfigureDefault.Get(""));

        var expected = await this.systemUnderTest.GetTimeSeriesAsync("2011-01-01", "2011-01-01", apiKey: "123");

        Assert.Equal(expected.Success, fakeData.Success);
    }
}
