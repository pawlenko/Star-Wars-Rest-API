using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;
using System.Net.Http;

namespace SW.API.Integration.Test.Fixtures
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixture()
        {

            var builder = new WebHostBuilder()
                   .UseContentRoot(GetProjectPath())
                   .UseEnvironment("Development")
                    .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(GetProjectPath())
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                   .UseStartup<Startup>();  

            _testServer = new TestServer(builder);
            Client = _testServer.CreateClient();

        }

        string GetProjectPath()
        {
            string appRootPath = Path.GetFullPath(Path.Combine(
                       AppContext.BaseDirectory,
                       "..", "..", "..", "..", "SW.API"));

            return appRootPath;
        }


        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            var relativePathToHostProject ="";
            return Path.Combine(testProjectPath, relativePathToHostProject);
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
