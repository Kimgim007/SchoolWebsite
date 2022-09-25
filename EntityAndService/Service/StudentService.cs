using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;

namespace People.EntityAndService.Service
{
    public class StudentService
    {
        private StudentRepository repository { get; set; }
        public StudentService(StudentRepository studentRepository)
        {
            this.repository = studentRepository;
        }     
        public void Remove(int id)
        {
            this.repository.RemoveStudent(id);
        }
        public void AddStudent(Student student)
        {
            repository.Add(MapingService.map(student));
        }
        public void AddStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                this.repository.Add(MapingService.map(student));
            }
        }
        public void UpdateStudent(Student student)
        {
           this.repository.Update(MapingService.map(student));

        }
        public Student GetStudent(int Id)
        {           
            return MapingService.map(this.repository.Get(Id),true);
        }
        public List<Student> GetStudents()
        {
            return this.repository.GetAll().Select(S=>MapingService.map(S,true)).ToList();
        }
        public Student StudetnHoHaveMaxMark()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,true));
            double maxBall = students.Max(st => st.GetAveregeMark());
            Student student = students.First(st => st.GetAveregeMark() == maxBall);
            return student;
        }
        public Student StudetnHoHaveLowMark()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,true));
            double maxBall = students.Min(st => st.GetAveregeMark());
            Student student = students.First(st => st.GetAveregeMark() == maxBall);
            return student;
        }
        public List<Student> SortingByName()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,false));
            var studentsNew = students.OrderBy(st => st.Name).ToList();
            return studentsNew;
        }
        public List<Student> SortingByGender()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,false));
            var studentsNew = students.OrderBy(st => st.Gender).ToList();
            return studentsNew;
        }
        public List<Student> SortingByAge()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,false));
            var studentsNew = students.OrderBy(st => st.Age()).ToList();
            return studentsNew;

        }
        public Gender WhoStudiesBetter()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,true));
            double male = students.Where(st => st.Gender == Gender.male).Average(st => st.GetAveregeMark());
            double female = students.Where(st => st.Gender == Gender.female).Average(st => st.GetAveregeMark());
            if (male > female)
            {
                return Gender.male;
            }
            else
            {
                return Gender.female;
            }
        }
        public double AverageAgeByGroup()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,false));
            double averegeAge = students.Average(st => st.Age());
            return averegeAge;
        }
        public string AverageScoreForBoysAndGirls()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,true));
            var averegeMarkforMen = students.Where(st => st.Gender == Gender.male).Average(st => st.GetAveregeMark());
            var averegeMarkforFemen = students.Where(st => st.Gender == Gender.female).Average(st => st.GetAveregeMark());
            return ($"Средняя оценка у мальчиков {averegeMarkforMen}" + "  " + $"Средняя оценка у девочек {averegeMarkforFemen}");

        }
        public List<IGrouping<char,Student>> GrupStudetsByFirstWord()
        {
            var students = repository.GetAll().Select(s=> MapingService.map(s,false));
            var groppStudenForFirsWord = students.GroupBy(th => th.Name[0]).OrderBy(th => th.Key).ToList();
            //var studentsStr = string.Join('\n', groppStudenForFirsWord.Select(a => a.Key.ToString() + string.Join('\n', a)));
            return (groppStudenForFirsWord);
        }      
    }
}
