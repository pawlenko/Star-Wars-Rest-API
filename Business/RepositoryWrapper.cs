

using SW.Business.Contracts;
using SW.Business.Interface;
using SW.Business.Repositories;
using SW.Data;

namespace SW.Business
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;

        private ICharacterService _character;
        private IPlanetService _planet;
        private IEpisodeService _episode;
        private IFriendService _friend;
        private ICharacterEpisodeService _characterEpisode;


        public ICharacterEpisodeService CharacterEpisode
        {
            get
            {
                if (_characterEpisode == null)
                {
                    _characterEpisode = new CharacterEpisodeRepository(_repoContext);
                }

                return _characterEpisode;
            }
        }


        public IFriendService Friend
        {
            get
            {
                if (_friend == null)
                {
                    _friend = new FriendRepository(_repoContext);
                }

                return _friend;
            }
        }

        public ICharacterService Character
        {
            get
            {
                if (_character == null)
                {
                    _character = new CharacterRepository(_repoContext);
                }

                return _character;
            }
        }

        public IPlanetService Planet
        {
            get
            {
                if (_planet == null)
                {
                    _planet = new PlanetRepository(_repoContext);
                }

                return _planet;
            }
        }

        public IEpisodeService Episode
        {
            get
            {
                if (_episode == null)
                {
                    _episode = new EpisodeRepository(_repoContext);
                }

                return _episode;
            }
        }


        public RepositoryWrapper(ApplicationDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}