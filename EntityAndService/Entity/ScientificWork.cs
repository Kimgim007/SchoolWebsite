namespace People.EntityAndService.Entity
{
    public class ScientificWork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
       public ScientificWork() {}
        public ScientificWork(string Title, Subject subject,Teacher teacher,Student student)
        {
            this.Title = Title;
            this.Subject = subject;
            this.Teacher = teacher;
            this.Student = student;
        }
        public override string ToString()
        {
            return $"Это научная работа {Title} по предмету {Subject} курирует преподаватель - {Teacher.Name} написал - {Student.Name}";
        }
    }
}
