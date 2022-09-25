using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest1.Entity
{
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Team1Id { get; set; }
        public virtual Team Team1 { get; set; }
        public int CheckTeam1 { get; set; }

        public int Team2Id { get; set; }
        public virtual Team Team2 { get; set; }
        public int CheckTeam2 { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
