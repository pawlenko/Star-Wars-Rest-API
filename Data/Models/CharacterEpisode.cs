using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Data.Models
{
    public class CharacterEpisode : BaseEntity
    {

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public int EpisodeId { get; set; }
        public virtual Episode Episode { get; set; }

    }
}
