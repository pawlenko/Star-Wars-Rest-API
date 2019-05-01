using Data.Models;
using SW.Business.Contracts;
using SW.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SW.Unit.Test.Scenarios
{
    public class PlanetRepositoryTest
    {
        IPlanetService repo;

        public PlanetRepositoryTest()
        {
            repo = new TestRepositoryWrapper().RepoWraper.Planet;

        }



        [Fact]
        public async Task Add_WithName()
        {
            var result = await repo.CreatePlanetAsync("fafa");

            Assert.True(result.Id > 0);
            Assert.Equal("fafa", result.Name);

        }

        [Fact]
        public async Task Get_PlanetById()
        {

             await repo.CreatePlanetAsync("fafa");

            var result = await repo.GetPlanetById(1);

            Assert.True(result.Id > 0);
            Assert.True(result != null);
            Assert.Equal("fafa", result.Name);

        }

        [Fact]
        public async Task Delete_Planet()
        {
            var result =  await repo.CreatePlanetAsync("fafa");

            Assert.True(result.Id > 0);
            Assert.True(result != null);


            await repo.DeletePlanetAsync(result);

            result = await repo.GetPlanetById(1);
            int planetCount = await repo.PlanetCount();


            Assert.True(result == null);
            Assert.Equal<int>(0, planetCount);
        }



        [Fact]
        public async Task Update_Planet()
        {
            var previousName = "fafa";
            var newName = "fafa2";

            var result = await repo.CreatePlanetAsync(previousName);

            Assert.True(result.Id > 0);
            Assert.True(result != null);

            result.Name = newName;

            result =  await repo.UpdatePlanetAsync(result);

           
            Assert.True(result != null);
            Assert.Equal(newName, result.Name);
        }


    }
}
