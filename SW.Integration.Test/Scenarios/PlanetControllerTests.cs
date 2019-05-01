using Newtonsoft.Json;
using SW.API.Integration.Test.Fixtures;
using SW.Business.DTO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SW.API.Integration.Test.Scenarios
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
            var response = await _fixture.Client.GetAsync("api/Planet?page=1&count=1");

            Assert.True(response.IsSuccessStatusCode);
        }




        [Fact]
        public async Task PostPlanetWithoutNameReturnBadRequest()
        {
            PlanetAddDTO addPlanetDto = new PlanetAddDTO();
            addPlanetDto.Name = "";


            var content = new StringContent(JsonConvert.SerializeObject(addPlanetDto), Encoding.UTF8, "application/json");
            var response = await _fixture.Client.PostAsync("api/Planet/", content);

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }



        [Fact]
        public async Task GetPlanetThatNotExistReturnBadRequest()
        {
            var response = await _fixture.Client.GetAsync("api/Planet/-1");

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }




    }
}
