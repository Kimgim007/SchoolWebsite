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

        private DataContext _DataContext;

        public TeacherRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(TeacherDTO teacher)
        {
            _DataContext.Teachers.Add((teacher));
            _DataContext.SaveChanges();

        }
        public TeacherDTO Get(int id)
        {

            var teacher = _DataContext.Teachers
                .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                .Include(_ => _.ScientificWorks.Select(t => t.Student))
                .Include(_ => _.ScientificWorks.Select(t => t.Subject))
                .FirstOrDefault(th => th.Id == id);
            return teacher;

        }
        public List<TeacherDTO> GetAll()
        {

            return _DataContext.Teachers
                .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                .Include(_ => _.ScientificWorks.Select(t => t.Student))
                .Include(_ => _.ScientificWorks.Select(t => t.Subject)).ToList();

        }
        public void Update(TeacherDTO teacher)
        {

            var updateTeacher = _DataContext.Teachers.FirstOrDefault(th => th.Id == teacher.Id);
            if (updateTeacher != null)
            {
                updateTeacher.Name = teacher.Name;
                updateTeacher.Birthday = teacher.Birthday;
                updateTeacher.Gender = teacher.Gender;
                updateTeacher.ZP = teacher.ZP;
                _DataContext.SaveChanges();
            }

        }
    }
}
