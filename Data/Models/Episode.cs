using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Episode : BaseEntity
    {
   

        public string Name { get; set; }


        public virtual ICollection<CharacterEpisode> Characters { get; set; }



    }
}
