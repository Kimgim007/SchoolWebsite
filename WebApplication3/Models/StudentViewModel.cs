using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MyFirstProject.Models
{
    public class StudentViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public int GenderId { get; set; }
        public List<SelectListItem> Genders { get; set; }


      
    }
}
