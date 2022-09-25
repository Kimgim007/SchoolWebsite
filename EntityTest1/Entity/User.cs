using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest1.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Game> Games { get; set; } = new List<Game>();

        
        public User() { }
        public User(string Name) 
        {
            this.Name = Name;
        }
        public override string ToString()
        {
            var games = Games;
            var lisst = new List<string>();
            foreach (var game in games)
            {
                lisst.Add(game.Name);
            }
            return $"{Id} - Это пользователь с именем {Name} ";
        }
    }
}
