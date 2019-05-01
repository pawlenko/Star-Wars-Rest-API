using Data.Models;
using SW.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Business.Contracts
{
   public interface IPlanetService 
    {
        Task<IEnumerable<Planet>> GetPlanetRange(int index, int count);
        Task<bool> CheckPlanetWithNameExist(string name);
        Task<bool> CheckPlanetWithCharacterExist(Character character,Planet planet);
        Task<Planet> GetPlanetById(int id);
        Task DeletePlanetAsync(Planet planet);
        Task<Planet> UpdatePlanetAsync(Planet planet);
        Task<Planet> CreatePlanetAsync(string name);
        Task<int> PlanetCount();

    }
}