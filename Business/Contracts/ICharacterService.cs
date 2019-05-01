using Data.Models;
using SW.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Business.Contracts
{
    public interface ICharacterService 
    {
        Task<IEnumerable<Character>> GetCharacterRange(int index, int count);
        Task<Character> GetCharacterById(int id);
        Task DeleteCharacterAsync(Character character);
        Task<Character> UpdateCharacterAsync(Character character);
        Task<Character> CreateCharacterAsync(string name);
        Task<int> CharacterCount();

    }
}