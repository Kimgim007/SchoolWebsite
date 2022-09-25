using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1;
using Test1Context.Repository.Interface;
using System.Data.Entity;
namespace Test1Context.Repository
{
    public class GameRepository : Interface<GameDTO>
    {
        public void Add(GameDTO obj)
        {
            using (var context = new Test1ContextContext())
            {
                context.Games.Add(obj);
                context.SaveChanges();
            }
        }

        public GameDTO Get(int id)
        {
            using(var context = new Test1ContextContext())
            {
                var game = context.Games.Include(_ => _.Users).FirstOrDefault(G => G.Id == id);
                return game;
            }
        }

        public List<GameDTO> GetAll()
        {
            using (var context = new Test1ContextContext())
            {
                return context.Games.Include(_=>_.Users).ToList();
            }
        }
    }
}
