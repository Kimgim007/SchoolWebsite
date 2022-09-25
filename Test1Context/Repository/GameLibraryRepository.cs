using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Test1;
using Test1Context.DTO;
using Test1Context.Repository.Interface;

namespace Test1Context.Repository
{
    public class GameLibraryRepository : Interface<GamesLibraryDTO>
    {

        public void Add(GamesLibraryDTO obj)
        {
            using (var context = new Test1ContextContext())
            {
                context.GamesLibrary.Add(obj);
                context.SaveChanges();
            }
        }

        public GamesLibraryDTO Get(int id)
        {
            using (var context = new Test1ContextContext())
            {
                return context.GamesLibrary.FirstOrDefault(G => G.Id == id);
            }
        }

        public List<GamesLibraryDTO> GetAll(int id)
        {
            using(var context = new Test1ContextContext())
            {
                var list = context.GamesLibrary.Include(_=>_.User).Include(_=>_.Game).Where(l=>l.Id == id).ToList();
           
                return list;
            }
        }

        public List<GamesLibraryDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
