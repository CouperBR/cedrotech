using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Tests.Fixtures;
using Xunit;

namespace WebAPI.Tests.Scenarios
{
    public class PratoTest
    {
        private readonly TestContext _testContext;
        public PratoTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/prato");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
