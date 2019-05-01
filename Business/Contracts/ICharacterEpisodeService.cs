using Data.Models;
using SW.Data.Models;
using System.Threading.Tasks;

namespace SW.Business.Contracts
{
    public interface  ICharacterEpisodeService
    {
        Task<CharacterEpisode> GetEpisode(Character parent, Episode child);
        Task<CharacterEpisode> AddEpisode(Character parent, Episode child);
        Task RemoveEpisode(CharacterEpisode state);
    }
}