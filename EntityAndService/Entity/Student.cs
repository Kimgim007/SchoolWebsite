using System;
using System.Collections.Generic;
namespace People.EntityAndService.Entity
{
    public class Student : Person
    {
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public List<ScientificWork> ScientificWork { get; set; }
        public Student()
        {
        }
        public Student(string name, string Birthday, string gender) : base(name, Birthday, gender)
        {
        }

        public Student(string name, DateTime Birthday, int gender) : base(name, Birthday, gender)
        {
        }
        public double GetAveregeMark()
        {
            double sum = 0;
            foreach (var item in this.Grades)
            {
                sum += item.Value;
            }
            return sum / Grades.Count;
        }
        public double AverageMarkForSubject(string Subject)
        {
            double sum = 0;
            int count = 0;
            foreach (var item in Grades)
            {
                if (item.Lecture.Subject.Title == Subject)
                {
                    sum += item.Value;
                    count++;
                }
            }

            return sum / count;
        }
        public override string ToString()
        {

            return $"{Id}-Id. Это {Name}";
        }
    }
}
