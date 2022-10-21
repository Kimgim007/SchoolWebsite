using People.EntityAndService.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface IStudentService
    {
        Task AddStudent(Student student);
        Task AddStudents(List<Student> students);
        //Task<double> AverageAgeByGroup();
        //Task<string> AverageScoreForBoysAndGirls();
        Task<Student> GetStudent(int Id);
        Task<List<Student>> GetStudents();
        //Task<List<IGrouping<char, Student>>> GrupStudetsByFirstWord();
        Task Remove(int id);
        //Task<List<Student>> SortingByAge();
        //Task<List<Student>> SortingByGender();
        //Task<List<Student>> SortingByName();
        //Task<Student> StudetnHoHaveLowMark();
        //Task<Student> StudetnHoHaveMaxMark();
        Task UpdateStudent(Student student);
        //Task<Gender> WhoStudiesBetter();
    }
}