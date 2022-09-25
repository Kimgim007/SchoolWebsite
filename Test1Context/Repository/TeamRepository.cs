using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1;
using Test1Context.Repository.Interface;

namespace Test1Context.Repository
{
    public class TeamRepository: Interface<TeamDTO>
    {
        public void Add(TeamDTO obj)
        {
            using (var context = new Test1ContextContext())
            {
                context.Teams.Add(obj);
                context.SaveChanges();
            }
        }

        public TeamDTO Get(int id)
        {
            using (var context = new Test1ContextContext())
            {
                var game = context.Teams.FirstOrDefault(G => G.Id == id);
                return game;
            }
        }

        public List<TeamDTO> GetAll()
        {
            using (var context = new Test1ContextContext())
            {
                return context.Teams.ToList();
            }
        }
    }
}
