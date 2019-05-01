using SW.Business.Contracts;
using SW.Data;
using SW.Data.Models;
using SW.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Data.Models;
using SW.Business.DTO;
using System.Threading.Tasks;

namespace SW.Business.Repositories 
{ 
   public class FriendRepository : Repository<Friend>, IFriendService
    {
        public FriendRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<Friend> AddFriend(Character parent, Character child)
        {
            var temp = new Friend();
            temp.CharacterId = parent.Id;
            temp.FriendId = child.Id;

            return await CreateAsync(temp);
        }

        public async Task<Friend> GetFriend(Character parent, Character child)
        {
            return await FindAsync(x => x.Character == parent && x.Friends == child);
        }

        public async Task RemoveFriend(Friend friend)
        {
            await DeleteAsync(friend);
        }
    }

}