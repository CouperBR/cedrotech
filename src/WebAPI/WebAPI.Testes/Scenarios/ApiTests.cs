using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Testes.Fixtures;
using Xunit;

namespace WebAPI.Testes.Scenarios
{
    public class ApiTests
    {

        private readonly TestContext _testContext;

        public ApiTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Prato_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/prato");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
