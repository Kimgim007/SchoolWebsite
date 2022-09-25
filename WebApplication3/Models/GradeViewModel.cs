using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstProject.Models
{
    public class GradeViewModel
    {
        public int Id { get; set; } 
        public int Value { get; set; }
        public int StudentId { get; set; }
     
        public int LectureId { get; set; }
        public  List<SelectListItem> Lectures { get; set; }
    }
}
