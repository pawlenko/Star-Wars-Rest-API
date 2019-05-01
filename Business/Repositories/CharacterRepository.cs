using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using SW.Business.Contracts;
using SW.Data;
using SW.Repository;
using Microsoft.EntityFrameworkCore;

namespace SW.Business.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterService
    {
        public CharacterRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

     

        public async Task<Character> GetCharacterById(int id)
        {
            return await FindAsync(x=>x.Id == id, s => s.Include(c => c.Episodes).ThenInclude(c => c.Episode).Include(c => c.Friends).ThenInclude(c => c.Friends).Include(c=>c.FriendFor).ThenInclude(c=>c.Character).Include(x=>x.Planet));
        }

        public async Task<IEnumerable<Character>> GetCharacterRange(int index, int count)
        {
         
           return await GetRangeAsync(index, count,s=>s.Include(c=>c.Episodes).ThenInclude(c=>c.Episode).Include(c=>c.Friends).ThenInclude(c=>c.Friends).Include(c => c.FriendFor).ThenInclude(c => c.Character).Include(x => x.Planet));
        }

        public async Task<Character> UpdateCharacterAsync(Character character)
        {
           return  await UpdateAsync(character);
        }

        public async Task<int> CharacterCount()
        {
            return await CountAsync();
        }

        public async Task<Character> CreateCharacterAsync(string name)
        {
            var temp = new Character();
            temp.Name = name;

            return await CreateAsync(temp);
        }


        public async Task DeleteCharacterAsync(Character character)
        {
            await DeleteAsync(character);
        }

    }
}