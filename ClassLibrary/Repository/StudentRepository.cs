using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
namespace People.Data.Repository
{
    public class StudentRepository: IRepository<StudentDTO>
    {

        public void Add(StudentDTO student)
        {
            using (var Db = new DataContext())
            {
                Db.Students.Add((student));
                Db.SaveChanges();
            }
        }
        public StudentDTO Get(int Id)
        {
            using (var Db = new DataContext())
            {
                var student = Db.Students
                    .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                    .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                    .Include(_ => _.ScientificWork.Select(t=>t.Teacher))
                    .Include(_ => _.ScientificWork.Select(t => t.Student))
                    .Include(_ => _.ScientificWork.Select(t => t.Subject))
                    .FirstOrDefault(St => St.Id == Id);               
                return (student);                         
            }
        }
        public List<StudentDTO> GetAll()
        {
            using (var Db = new DataContext())
            {
                return Db.Students
                    .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                    .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                    .Include(_=>_.ScientificWork)
                    .Include(_ => _.ScientificWork.Select(t => t.Teacher))
                    .Include(_ => _.ScientificWork.Select(t => t.Student))
                    .Include(_ => _.ScientificWork.Select(t => t.Subject)).ToList();
            }
        }    
        public void Update(StudentDTO student)
        {
            using (var Db = new DataContext())
            {
                var updateStudent = Db.Students.FirstOrDefault(St => St.Id == student.Id);
                if (updateStudent != null)
                {
                    updateStudent.Name = student.Name;
                    updateStudent.Birthday = student.Birthday;
                    updateStudent.Gender = student.Gender;       
                    Db.SaveChanges();
                }
            }
        }
        public void RemoveStudent(int id)
        {
            using (var Db = new DataContext())
            {
                var student = Db.Students.FirstOrDefault(St => St.Id == id);
                if (student != null)
                {
                    Db.Students.Remove(student);
                    Db.SaveChanges();
                }

            }
        }

    }
}
