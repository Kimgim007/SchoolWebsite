using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test1Context.DTO;

namespace Test1
{
    public class GameDTO:ObjectDTO
    {
     
     
        public string Name { get; set; }
        public virtual List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
