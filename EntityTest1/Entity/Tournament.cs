using System;
using System.Collections.Generic;
using System.Text;
using Test1;

namespace EntityTest1.Entity
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GameId { get; set; }
        public virtual GameDTO Game { get; set; }

        public virtual List<Team> Teams { get; set; } = new List<Team>();
        public virtual List<Match> Matches { get; set; } = new List<Match>();
    }
}
