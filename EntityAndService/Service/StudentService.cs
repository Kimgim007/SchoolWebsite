using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class StudentService : IStudentService
    {
        private StudentRepository repository { get; set; }
        public StudentService(StudentRepository studentRepository)
        {
            this.repository = studentRepository;
        }
        public async Task Remove(int id)
        {
            await this.repository.RemoveStudent(id);
        }
        public async Task AddStudent(Student student)
        {
            await repository.Add(MapingService.map(student));
        }
        public async Task AddStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                await this.repository.Add(MapingService.map(student));
            }
        }
        public async Task UpdateStudent(Student student)
        {
            await this.repository.Update(MapingService.map(student));

        }
        public async Task<Student> GetStudent(int Id)
        {
            return MapingService.map(await this.repository.Get(Id), true);
        }
        public async Task<List<Student>> GetStudents()
        {
            var students = await this.repository.GetAll();
            return students.Select(S => MapingService.map(S, true)).ToList();
        }
        //public async Task<Student> StudetnHoHaveMaxMark()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, true));
        //    double maxBall = students.Max(st => st.GetAveregeMark());
        //    Student student = students.First(st => st.GetAveregeMark() == maxBall);
        //    return student;
        //}
        //public async Task<Student> StudetnHoHaveLowMark()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, true));
        //    double maxBall = students.Min(st => st.GetAveregeMark());
        //    Student student = students.First(st => st.GetAveregeMark() == maxBall);
        //    return student;
        //}
        //public async Task<List<Student>> SortingByName()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, false));
        //    var studentsNew = students.OrderBy(st => st.Name).ToList();
        //    return studentsNew;
        //}
        //public async Task<List<Student>> SortingByGender()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, false));
        //    var studentsNew = students.OrderBy(st => st.Gender).ToList();
        //    return studentsNew;
        //}
        //public async Task<List<Student>> SortingByAge()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, false));
        //    var studentsNew = students.OrderBy(st => st.Age()).ToList();
        //    return studentsNew;

        //}
        //public async Task<Gender> WhoStudiesBetter()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, true));
        //    double male = students.Where(st => st.Gender == Gender.male).Average(st => st.GetAveregeMark());
        //    double female = students.Where(st => st.Gender == Gender.female).Average(st => st.GetAveregeMark());
        //    if (male > female)
        //    {
        //        return Gender.male;
        //    }
        //    else
        //    {
        //        return Gender.female;
        //    }
        //}
        //public async Task<double> AverageAgeByGroup()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, false));
        //    double averegeAge = students.Average(st => st.Age());
        //    return averegeAge;
        //}
        //public async Task<string> AverageScoreForBoysAndGirls()
        //{
        //    var students = await repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, true));
        //    var averegeMarkforMen = students.Where(st => st.Gender == Gender.male).Average(st => st.GetAveregeMark());
        //    var averegeMarkforFemen = students.Where(st => st.Gender == Gender.female).Average(st => st.GetAveregeMark());
        //    return ($"Средняя оценка у мальчиков {averegeMarkforMen}" + "  " + $"Средняя оценка у девочек {averegeMarkforFemen}");

        //}
        //public async Task<List<IGrouping<char, Student>>> GrupStudetsByFirstWord()
        //{
        //    var students = repository.GetAll();
        //    var studentsSort = students.Select(s => MapingService.map(s, false));
        //    var groppStudenForFirsWord = students.GroupBy(th => th.Name[0]).OrderBy(th => th.Key).ToList();
        //    //var studentsStr = string.Join('\n', groppStudenForFirsWord.Select(a => a.Key.ToString() + string.Join('\n', a)));
        //    return (groppStudenForFirsWord);
        //}
    }
}
