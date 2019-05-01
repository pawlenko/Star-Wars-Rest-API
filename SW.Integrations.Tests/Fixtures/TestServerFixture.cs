using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SW.API;
using System;
using System.Net.Http;

namespace SW.Integrations.Tests.Fixtures
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                   .UseEnvironment("Development")
                   .UseStartup<Startup>();  // Uses Start up class from your API Host project to configure the test server

            _testServer = new TestServer(builder);
            Client = _testServer.CreateClient();

        }


        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
