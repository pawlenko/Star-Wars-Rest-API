using SW.Business.Contracts;

namespace SW.Business.Interface
{
    public interface IRepositoryWrapper
    {
        ICharacterService Character { get; }
        IPlanetService Planet { get; }
        IEpisodeService Episode { get; }
        IFriendService Friend { get; }
        ICharacterEpisodeService CharacterEpisode { get;  }
    }
}