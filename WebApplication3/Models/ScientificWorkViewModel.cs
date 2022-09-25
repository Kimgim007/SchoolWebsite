using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstProject.Models
{
    public class ScientificWorkViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; } 
        public string Title { get; set; }

        public int TeacherId { get; set; }
        public List<SelectListItem> Teachers { get; set; }

        public int SubjectId { get; set; }
        public List<SelectListItem> Subjects { get; set; }
    }
}
