using Data.DTO;
using System;
using System.Collections.Generic;

namespace People.Data.DTO
{
    public class StudentDTO : ObjectDTO
    {
    
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public GenderLib Gender { get; set; }     
        public  virtual List<GradeDTO> Grades { get; set; }
        public StudentDTO()
        {
            this.Grades = new List<GradeDTO>();
        }
        //public int ScientificWorkId { get; set; }
        public virtual List<ScientificWorkDTO> ScientificWork { get; set; }
    }
}
