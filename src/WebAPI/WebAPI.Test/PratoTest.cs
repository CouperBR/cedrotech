using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Services;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using System.Collections.Generic;

namespace WebAPI.Test
{
    public class PratoTest
    {
        private readonly HttpClient _client;
        private DbContextOptions<Context> options;

        public PratoTest()
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
                var mock = new Mock<IPratoService>();
                mock.Setup(p => p.Get(1)).Returns(new prato());
                var result = mock.Object.Get(1);
                result.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task OnGet_ShouldNotBeThrowError()
        {
            using (var context = new Context(options))
            {
                var mock = new Mock<IPratoService>();
                mock.Setup(p => p.Get("teste")).Returns(new List<prato>());
                var result = mock.Object.Get("teste");
                result.Should().NotBeNull();
            }
        }


    }
}
