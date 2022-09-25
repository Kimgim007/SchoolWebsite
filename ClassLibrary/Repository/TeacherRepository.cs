using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
namespace People.Data.Repository
{
    public class TeacherRepository : IRepository<TeacherDTO>
    {
        public void Add(TeacherDTO teacher)
        {
            using (DataContext Db = new DataContext())
            {
                Db.Teachers.Add((teacher));
                Db.SaveChanges();
            }
        }
        public TeacherDTO Get(int id)
        {
            using (var Db = new DataContext())
            {
                var teacher = Db.Teachers
                    .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                    .Include(_ => _.ScientificWorks.Select(t => t.Student))
                    .Include(_ => _.ScientificWorks.Select(t => t.Subject))
                    .FirstOrDefault(th => th.Id == id);
                return teacher;         
            }
        }
        public List<TeacherDTO> GetAll()
        {
            using (var Db = new DataContext())
            {
                return Db.Teachers
                    .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                    .Include(_ => _.ScientificWorks.Select(t => t.Student))
                    .Include(_ => _.ScientificWorks.Select(t => t.Subject)).ToList();
            }
        }
        public void Update(TeacherDTO teacher)
        {
            using (var Db = new DataContext())
            {
                var updateTeacher = Db.Teachers.FirstOrDefault(th => th.Id == teacher.Id);
                if (updateTeacher != null)
                {
                    updateTeacher.Name = teacher.Name;
                    updateTeacher.Birthday = teacher.Birthday;
                    updateTeacher.Gender = teacher.Gender;
                    updateTeacher.ZP = teacher.ZP;
                    Db.SaveChanges();
                }
            }
        }
    }
}
