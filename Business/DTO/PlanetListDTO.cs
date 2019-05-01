
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SW.Business.DTO
{
    public class PlanetListDTO
    {
      public ICollection<PlanetDTO> Result { get; set; }
      public int Total { get; set; }
    }
}