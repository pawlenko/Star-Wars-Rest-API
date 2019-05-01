using System.Collections.Generic;

namespace SW.Business.DTO
{

   

    public class CharacterDTO
    {

     


        public string Name { get; set; }
        public string Planet { get; set; }
        public ICollection<string> Episodes { get; set; }
        public ICollection<string> Friends { get; set; }

    }
}
