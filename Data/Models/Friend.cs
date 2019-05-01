using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Data.Models
{
    public  class Friend
    {
        public int CharacterId { get; set; }
        public int FriendId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Character Friends { get; set; }
    }
}
