using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Services;
using Xunit;

namespace WebAPI.Test
{
    public class PedidoTest
    {
        private readonly HttpClient _client;
        private DbContextOptions<Context> options;

        public PedidoTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<StartupApiTests>()
                );

            _client = server.CreateClient();

            options = new DbContextOptionsBuilder<Context>()
           .UseInMemoryDatabase("db")
           .Options;
        }

        [Fact]
        public async Task OnGet_ShouldNotBeThrowError()
        {
            using (var context = new Context(options))
            {
                var mock = new Mock<IPedidoService>();
                mock.Setup(p => p.Get()).Returns(new List<pedido>());
                var result = mock.Object.Get();
                result.Should().NotBeNull();
            }
        }
    }
}
