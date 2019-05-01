
using SW.Business.Contracts;
using SW.Repository;
using Data.Models;
using SW.Data;
using System.Threading.Tasks;
using SW.Business.DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SW.Business.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetService
    {
        public PlanetRepository(ApplicationDbContext repositoryContext) :base(repositoryContext)
        {

        }


        public async Task<Planet> GetPlanetById(int id)
        {
            return await FindAsync(x => x.Id == id,s=>s.Include(c=>c.Character));
        }

        public async Task<IEnumerable<Planet>> GetPlanetRange(int index,int count)
        {
            return await GetRangeAsync(index, count);
        }


        public async Task<bool> CheckPlanetWithNameExist(string name)
        {
            return await FindAsync(x => x.Name == name) != null;
        }
 
        public async Task<int> PlanetCount()
        {
            return await CountAsync();
        }

        public async Task<Planet> CreatePlanetAsync(string name)
        {
            var newPlanet = new Planet();
            newPlanet.Name = name;

            return await CreateAsync(newPlanet);
        }

        public async Task<Planet> UpdatePlanetAsync(Planet planet)
        {
           return  await UpdateAsync(planet);
        }

        public async Task DeletePlanetAsync(Planet planet)
        {
             await DeleteAsync(planet);
        }

        public async Task<bool> CheckPlanetWithCharacterExist(Character character,Planet planet)
        {
            var temp = (await FindAsync(x=> x == planet && x.Character.Contains(character))) !=null;

            return temp;
        }

        
    }
}