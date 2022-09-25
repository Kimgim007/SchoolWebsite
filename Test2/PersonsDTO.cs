using System;
using System.Collections.Generic;
using System.Text;
using Test2.Objct;

namespace Test2
{
    public class PersonsDTO : ObjctDTO
    {
        public int ArtistsId { get; set; }
        public ArtistsDTO Artists { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        
    }
}
