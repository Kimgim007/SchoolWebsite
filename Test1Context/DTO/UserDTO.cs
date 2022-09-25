using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test1Context.DTO;

namespace Test1
{
    public class UserDTO : ObjectDTO
    {
    
        public string Name { get; set; }
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        public List<GameDTO> Games { get; set; } = new List<GameDTO>();

        
   
    }
}
