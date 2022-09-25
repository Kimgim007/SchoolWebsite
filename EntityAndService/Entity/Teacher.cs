using System;
using System.Collections.Generic;
using System.Linq;
namespace People.EntityAndService.Entity
{
    public class Teacher : Person
    {

        public double ZP { get; set; }
        public List<Lecture> Lecture { get; set; } = new List<Lecture>();
        public List<ScientificWork> scientificWorks { get; set; }
        public Teacher() { }
        public Teacher(string name, string Birthday, string gender, string ZP) : base(name, Birthday, gender)
        {
            this.ZP = Double.Parse(ZP);
        }
        public Teacher(string name, DateTime Birthday, string gender, string ZP) : base(name, Birthday, gender)
        {
            this.ZP = Double.Parse(ZP);
        }
        public Teacher(string name, DateTime Birthday, int gender, string ZP) : base(name, Birthday, gender)
        {
            this.ZP = Double.Parse(ZP);
        }
        public List<IGrouping<DateTime, Lecture>> LectureCount()
        {
            var grup = Lecture.GroupBy(th => th.DateTime.Date).OrderBy(th => th.Key).ToList();
            return grup;

        }
     
    }
}
