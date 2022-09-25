using EntityTest1.Entity;
using Test1Context.Repository;
using People.EntityTest1.Maping;
using System.Linq;
using System.Collections.Generic;

namespace EntityTest1.Service
{
    public class UserService
    {
       private UserRepository repository { get; set; } = new UserRepository();

        public void Add(User user)
        {
            this.repository.Add(Maping.map(user));
        }
        public User Get(int id)
        {
            return Maping.map(this.repository.Get(id), false);
        }

        public List<User> GetAll()
        {
            return this.repository.GetAll().Select(U => Maping.map(U, true)).ToList();
        }
     
    }
}
