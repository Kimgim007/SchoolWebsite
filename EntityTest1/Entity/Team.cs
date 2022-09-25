using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest1.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        //public  List<Tournament> Tournaments { get; set; } = new List<Tournament>();
        public Team() { }
        public Team(string Name,Game Game)
        {
            this.Name = Name;
            this.Game = Game;
        }
        public override string ToString()
        {
            var users = Users;
            var list = new List<string>();
            foreach (var user in users)
            {
                list.Add(user.Name);
            }
            return $"Это команда под названием {Name} по игре {Game}, а это её участники {string.Join('\n', list)}";
        }
    }
}
