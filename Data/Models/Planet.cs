using SW.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Planet : BaseEntity
    {
        public string Name { get; set; }


        public virtual ICollection<Character> Character { get; set; }


    }
}
