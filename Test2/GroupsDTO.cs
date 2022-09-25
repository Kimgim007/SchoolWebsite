using System;
using System.Collections.Generic;
using System.Text;
using Test2.Objct;

namespace Test2
{
    public class GroupsDTO : ObjctDTO
    {

        public int ArtistsId { get; set; }
        public ArtistsDTO Artists { get; set; }
        public string Group_Name { get; set; }
    }
}
