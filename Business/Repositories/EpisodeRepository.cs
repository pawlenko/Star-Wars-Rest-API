using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using SW.Business.Contracts;
using SW.Data;
using SW.Repository;

namespace SW.Business.Repositories
{
    public class EpisodeRepository : Repository<Episode>, IEpisodeService
    {
        public EpisodeRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<Episode> GetEpisodeById(int id)
        {
            return await FindAsync(x => x.Id == id);
        }

        public  async Task<IEnumerable<Episode>> GetEpisodeRange(int index, int count)
        {
            return await GetRangeAsync(index, count);
        }

        public  async Task<bool> CheckEpisodeWithNameExist(string name)
        {
            return await FindAsync(x => x.Name == name) != null;
        }

        public async Task<Episode> CreateEpisodeAsync(string name)
        {
            var newPlanet = new Episode();
            newPlanet.Name = name;

            return await CreateAsync(newPlanet);
        }

        public  async Task DeleteEpisodeAsync(Episode episode)
        {
            await DeleteAsync(episode);
        }

        public async Task<int> EpisodeCount()
        {
            return await CountAsync();
        }


        public async Task<Episode> UpdateEpisodeAsync(Episode episode)
        {
            return await UpdateAsync(episode);
        }
    }
}