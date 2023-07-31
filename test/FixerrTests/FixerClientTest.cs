using System;
using System.Net.Http;
using Fixerr;
using Xunit;

namespace FixerrTests;

public class FixerClientTest
{
    [Fact]
    public void ShouldThrowException_WhenOptions_IsNotGiven()
    {
        Assert.Throws<ArgumentNullException>(() => new FixerClient(httpClient: new HttpClient()));
    }

    [Fact]
    public void ShouldThrowException_WhenHttpClient_IsNotProvided()
    {
        Assert.Throws<ArgumentNullException>(() => new FixerClient(httpClient: null));
    }
}
