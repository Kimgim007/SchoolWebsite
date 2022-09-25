using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1;
using Test1Context.Repository.Interface;
using System.Data.Entity;
namespace Test1Context.Repository
{
    public class UserRepository : Interface<UserDTO>
    {
        public void Add(UserDTO obj)
        {
            using (var context = new Test1ContextContext())
            {
                context.Users.Add(obj);
                context.SaveChanges();
            }
        }

        public UserDTO Get(int id)
        {
            using (var context = new Test1ContextContext())
            {
                var game = context.Users.Include(_ => _.Games).FirstOrDefault(G => G.Id == id);
                return game;
            }
        }

        public List<UserDTO> GetAll()
        {
            using (var context = new Test1ContextContext())
            {
                return context.Users.Include(_=>_.Games).ToList();
            }
        }
    }
}
