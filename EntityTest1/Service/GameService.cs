using EntityTest1.Entity;
using People.EntityTest1.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1Context.Repository;

namespace EntityTest1.Service
{
    public class GameService
    {
        private GameRepository repository { get; set; } = new GameRepository();

        public void Add(Game game)
        {
            this.repository.Add(Maping.map(game));
        }
        public Game Get(int id)
        {
            return Maping.map(repository.Get(id), false);
        }
        public List<Game> GetAll()
        {
            return repository.GetAll().Select(G=>Maping.map(G,true)).ToList();
        }
    }
}
