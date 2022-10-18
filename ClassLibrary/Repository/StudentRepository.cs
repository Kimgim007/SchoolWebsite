using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
namespace People.Data.Repository
{
    public class StudentRepository : IRepository<StudentDTO>
    {

        private DataContext _DataContext;

        public StudentRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(StudentDTO student)
        {

            _DataContext.Students.Add((student));
            _DataContext.SaveChanges();

        }
        public StudentDTO Get(int Id)
        {

            var student = _DataContext.Students
                .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                .Include(_ => _.ScientificWork.Select(t => t.Teacher))
                .Include(_ => _.ScientificWork.Select(t => t.Student))
                .Include(_ => _.ScientificWork.Select(t => t.Subject))
                .FirstOrDefault(St => St.Id == Id);
            return (student);

        }
        public List<StudentDTO> GetAll()
        {

            return _DataContext.Students
                .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                .Include(_ => _.ScientificWork)
                .Include(_ => _.ScientificWork.Select(t => t.Teacher))
                .Include(_ => _.ScientificWork.Select(t => t.Student))
                .Include(_ => _.ScientificWork.Select(t => t.Subject)).ToList();

        }
        public void Update(StudentDTO student)
        {

            var updateStudent = _DataContext.Students.FirstOrDefault(St => St.Id == student.Id);
            if (updateStudent != null)
            {
                updateStudent.Name = student.Name;
                updateStudent.Birthday = student.Birthday;
                updateStudent.Gender = student.Gender;
                _DataContext.SaveChanges();
            }

        }
        public void RemoveStudent(int id)
        {

            var student = _DataContext.Students.FirstOrDefault(St => St.Id == id);
            if (student != null)
            {
                _DataContext.Students.Remove(student);
                _DataContext.SaveChanges();
            }


        }

    }
}
