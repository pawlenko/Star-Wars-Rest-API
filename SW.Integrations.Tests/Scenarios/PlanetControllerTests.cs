using SW.Integrations.Tests.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace SW.Integrations.Tests.Scenarios
{
     public class PlanetControllerTests : IClassFixture<TestServerFixture>
    {

        private readonly TestServerFixture _fixture;

        public PlanetControllerTests(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetShouldReturnStatusCode200()
        {
            var response = await _fixture.Client.GetAsync("api/planet?page=1&count=1");

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }



    }
}
