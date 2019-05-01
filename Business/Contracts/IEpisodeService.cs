using Data.Models;
using SW.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Business.Contracts
{
    public interface IEpisodeService 
    {
        Task<IEnumerable<Episode>> GetEpisodeRange(int index, int count);
        Task<bool> CheckEpisodeWithNameExist(string name);
        Task<Episode> GetEpisodeById(int id);
        Task DeleteEpisodeAsync(Episode episode);
        Task<Episode> UpdateEpisodeAsync(Episode episode);
        Task<Episode> CreateEpisodeAsync(string name);
        Task<int> EpisodeCount();
    }
}