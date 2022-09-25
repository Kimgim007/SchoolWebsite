using System;
using System.Collections.Generic;
using System.Text;
using Test2.Objct;

namespace Test2
{
    public class AlbumsDTO : ObjctDTO
    {

        public int ArtistsId { get; set; }
        public ArtistsDTO Artists { get; set; }
        public string Album_Title { get; set; }
        public string Album_Yesr { get; set; }
        public string Album_Tracks { get; set; }
     
    }
}
