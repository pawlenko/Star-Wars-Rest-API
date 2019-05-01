using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Planet
    {

        public Planet()
        {
            CreateDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
