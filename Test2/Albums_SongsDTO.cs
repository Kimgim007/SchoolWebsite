using System;
using System.Collections.Generic;
using System.Text;

using Test2.Objct;

namespace Test2
{
    public class Albums_SongsDTO: ObjctDTO
    {

        public int SongId { get; set; }
        public SongsDTO Song { get; set; }

        public int AlbumId { get; set; }
        public AlbumsDTO Album { get; set; }
        public int Track_Number { get; set; }
    }
}
