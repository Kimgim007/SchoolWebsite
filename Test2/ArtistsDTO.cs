using System;
using Test2.Objct;

namespace Test2
{
    public class ArtistsDTO : ObjctDTO
    {
        public int GenresId { get; set; }
        public GenresDTO Genres { get; set; }

        public int CountriesId { get; set; }
        public CountriesDTO Countries { get; set; }

        public string Artist_Site_Url { get; set; }

    }
}
