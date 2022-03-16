using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixerr;
using Xunit;

namespace FixerrTests
{
    public class FixerClientTest
    {
        private IFixerClient fixerClient;

        [Fact]
        public void ShouldThrowException_WhenHttpClient_IsNotGiven()
        {
            Assert.Throws<NullReferenceException>(() => this.fixerClient = new FixerClient(null));
        }
    }
}
