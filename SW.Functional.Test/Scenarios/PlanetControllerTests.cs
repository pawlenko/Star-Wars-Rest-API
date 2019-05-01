using Newtonsoft.Json;
using SW.Business.DTO;
using SW.Functional.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SW.Functional.Test.Scenarios
{
    public class PlanetControllerTests : IClassFixture<TestServerFixture>
    {

        private readonly TestServerFixture _fixture;

        public PlanetControllerTests(TestServerFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task GetMultiPlanet()
        {
            var response = await _fixture.Client.GetAsync("api/Planet?page=1&count=1");

            Assert.True(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsStringAsync();

            Assert.True(result != null);

            var obj = JsonConvert.DeserializeObject<PlanetListDTO>(result);

            Assert.True(obj != null);
            Assert.True(obj.Result != null);
        }


        [Fact]
        public async Task PostPlanet()
        {
            PlanetAddDTO newPlanet = new PlanetAddDTO();
            newPlanet.Name = Guid.NewGuid().ToString();

            var content = new StringContent(JsonConvert.SerializeObject(newPlanet), Encoding.UTF8, "application/json");
            var response = await _fixture.Client.PostAsync("api/Planet/", content);


            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }



    }
}
