using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MyFirstProject.Models
{
    public class LecturesViewModel
    {
        public int id { get; set; }
        public string iteName { get; set; }
        public DateTime dataTime { get; set; }

        public int TeacherId { get; set; }
        public List<SelectListItem> Teachers { get; set; }

        public int SubjectId { get; set; }
        public List<SelectListItem> Subjects { get; set; }
    }
}
