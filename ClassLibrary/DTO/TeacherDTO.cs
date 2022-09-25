using Data.DTO;
using System;
using System.Collections.Generic;

namespace People.Data.DTO
{
    public class TeacherDTO : ObjectDTO
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public GenderLib Gender { get; set; }
        public double ZP { get; set; }
        public virtual List<LectureDTO> Lectures { get; set; }  
        public virtual List<ScientificWorkDTO> ScientificWorks { get; set; }
    }
}
