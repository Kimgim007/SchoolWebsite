using People.Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DTO
{
    public class ScientificWorkDTO : ObjectDTO
    {
        public string Title { get; set; }

        public int SubjectId { get; set; }
        public virtual SubjectDTO Subject { get; set; }

        public int TeacherId { get; set; }
        public virtual TeacherDTO Teacher { get; set; }

        public int StudentId { get; set; }
       
        public virtual StudentDTO Student { get; set; }
    }
}
