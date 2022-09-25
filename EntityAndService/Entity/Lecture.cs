using System;
using System.Collections.Generic;
namespace People.EntityAndService.Entity
{
    public class Lecture
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }  
        public List<Grade> Grades { get; set; }= new List<Grade>();
        public Subject Subject { get; set; }
        public DateTime DateTime { get; set; }
        public string itemName { get; set; }  
        public Lecture() { }
        public Lecture(Subject subject, DateTime dateTime, string itemName, Teacher teacher)
        {
            
            this.Subject = subject;
            this.DateTime = dateTime;   
            this.itemName = itemName;
            this.Teacher = teacher;
           
        }
        public override string ToString()
        {
            return $"Id-({Id}). Эта пара {Subject} , подраздел {itemName} , проходить будет {DateTime}, преподаватель {Teacher.Name}";
        }
       
    }
}
