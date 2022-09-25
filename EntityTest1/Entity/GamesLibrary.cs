using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest1.Entity
{
    public class GamesLibrary
    {
        public int Id { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
        public GamesLibrary()
        {

        }
        public GamesLibrary(Game Game,User User)
        {
            this.Game = Game;
            this.User= User;
        }
        public override string ToString()
        {
            return $"Это пользоваеть {User.Name} - и у него такой список игр: {string.Join('\n',Game.Name)}";
        }
    }
}
