using System;
using System.Collections.Generic;
using System.Text;
using Test1;

namespace Test1Context.DTO
{
    public class GamesLibraryDTO: ObjectDTO
    {
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }

        public int GameId { get; set; }
        public virtual GameDTO Game { get; set; }
    }
}
