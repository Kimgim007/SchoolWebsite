using System;
using System.Collections.Generic;
using System.Text;
using Test1Context.DTO;

namespace Test1
{
    public class TeamDTO : ObjectDTO
    {
     
        public string Name { get; set; }
        public int GameId { get; set; }
        public virtual GameDTO Game { get; set; }
        public virtual List<UserDTO> Users { get; set; } = new List<UserDTO>();
        //public virtual List<TournamentDTO> Tournaments { get; set; } = new List<TournamentDTO>();

    }
}
