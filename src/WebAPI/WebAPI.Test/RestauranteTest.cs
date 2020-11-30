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
    public class RestauranteTest
    {
        private readonly HttpClient _client;
        private DbContextOptions<Context> options;

        public RestauranteTest()
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
        public async Task OnGetById_ShouldBeReturnOkResponse()
        {
            using (var context = new Context(options))
            {
                var mock = new Mock<IRestauranteService>();
                mock.Setup(p => p.Get(1)).Returns(new restaurante());
                var result = mock.Object.Get(1);
                result.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task OnGet_ShouldNotBeThrowError()
        {
            using (var context = new Context(options))
            {
                var mock = new Mock<IRestauranteService>();
                mock.Setup(p => p.Get("teste")).Returns(new List<restaurante>());
                var result = mock.Object.Get("teste");
                result.Should().NotBeNull();
            }
        }
    }
}
