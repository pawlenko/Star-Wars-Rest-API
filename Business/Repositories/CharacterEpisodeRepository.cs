
using System.Threading.Tasks;
using Data.Models;
using SW.Business.Contracts;
using SW.Data;
using SW.Data.Models;
using SW.Repository;

namespace SW.Business.Repositories
{
    class CharacterEpisodeRepository : Repository<CharacterEpisode>, ICharacterEpisodeService
    {

        public CharacterEpisodeRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<CharacterEpisode> AddEpisode(Character parent, Episode child)
        {

            var temp = new CharacterEpisode();
            temp.CharacterId = parent.Id;
            temp.EpisodeId = child.Id;

            return await CreateAsync(temp);
        }

        public async Task<CharacterEpisode> GetEpisode(Character parent, Episode child)
        {
            return await FindAsync(x => x.Character == parent && x.Episode == child);
        }

        public async Task RemoveEpisode(CharacterEpisode state)
        {
            await DeleteAsync(state);
        }
    }
}