using Data.Models;
using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW.Business.Contracts
{
    public interface IFriendService
    {
        Task<Friend> GetFriend(Character parent, Character child);
        Task<Friend> AddFriend(Character parent, Character child);
        Task RemoveFriend(Friend friend);
    }
}