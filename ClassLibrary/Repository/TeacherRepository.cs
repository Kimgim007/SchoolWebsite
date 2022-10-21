using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class TeacherRepository : IRepository<TeacherDTO>
    {

        private DataContext _DataContext;

        public TeacherRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public async Task Add(TeacherDTO teacher)
        {
            _DataContext.Teachers.Add((teacher));
            await _DataContext.SaveChangesAsync();
        }
        public async Task<TeacherDTO> Get(int id)
        {
            var teacher = await _DataContext.Teachers
                .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                .Include(_ => _.ScientificWorks.Select(t => t.Student))
                .Include(_ => _.ScientificWorks.Select(t => t.Subject))
                .FirstOrDefaultAsync(th => th.Id == id);
            return teacher;
        }
        public async Task<List<TeacherDTO>> GetAll()
        {
            return await _DataContext.Teachers
                .Include(_ => _.ScientificWorks.Select(t => t.Teacher))
                .Include(_ => _.ScientificWorks.Select(t => t.Student))
                .Include(_ => _.ScientificWorks.Select(t => t.Subject)).ToListAsync();
        }
        public async Task Update(TeacherDTO teacher)
        {
            var updateTeacher = await _DataContext.Teachers.FirstOrDefaultAsync(th => th.Id == teacher.Id);
            if (updateTeacher != null)
            {
                updateTeacher.Name = teacher.Name;
                updateTeacher.Birthday = teacher.Birthday;
                updateTeacher.Gender = teacher.Gender;
                updateTeacher.ZP = teacher.ZP;
                await _DataContext.SaveChangesAsync();
            }
        }

    }
}
