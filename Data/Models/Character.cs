using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
   public class Character : BaseEntity
    {

       

        public string Name { get; set; }

        [ForeignKey("Planet")]
        public int? PlanetId { get; set; }
        public virtual Planet Planet { get; set; }

        public virtual ICollection<Friend>  Friends { get; set; }
        public virtual ICollection<Friend>  FriendFor { get; set; }
        public virtual ICollection<CharacterEpisode> Episodes { get; set; }





    }
}
