using EntityTest1.Entity;
using People.EntityTest1.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1Context.Repository;

namespace EntityTest1.Service
{
    public class GamesLibraryService
    {
        GameLibraryRepository Repository { get; set; }=new GameLibraryRepository();
        public void Add(GamesLibrary gamesLibrary)
        {
            Repository.Add(Maping.map(gamesLibrary));
        }
        public List<GamesLibrary> GetAll(int id)
        {
            return this.Repository.GetAll(id).Select(G=>Maping.map(G,true)).ToList();
        }
    }
}
