using System;
using System.Collections.Generic;

namespace People.Data.DTO
{
    public class LectureDTO : ObjectDTO
    {
        
        public string itemName { get; set; }
        public DateTime StartTime { get; set; }
   
        public int SubjectId { get; set; }
        public virtual SubjectDTO Subject { get; set; }
    
        public int TeacherId { get; set; }  
        public virtual TeacherDTO Teacher { get; set; }

        public virtual List<GradeDTO> Grades { get; set; }
        public LectureDTO()
        {
            this.Grades = new List<GradeDTO>();
        }
    }
}
