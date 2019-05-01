using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Character
    {

        public Character()
        {
            CreateDate = DateTime.UtcNow;
        }


        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }


        [ForeignKey("Planet")]
        public int PlanetId { get; set; }
        public virtual Planet  Planet { get; set; }

        public virtual ICollection<Episodes>  Episodes { get; set; }
        public virtual ICollection<Character> Friends { get; set; }

    }
}
