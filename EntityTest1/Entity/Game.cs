using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest1.Entity
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
        
        public Game() { }
        public Game(string Name)
        {
            this.Name = Name;
        }
        public override string ToString()
        {
            var users = Users;
            var list = new List<string>();
            foreach (var user in users)
            {
                list.Add(user.Name);
            }
            return $"{Id} Это игра под названием {Name}";
        }
    }
}
