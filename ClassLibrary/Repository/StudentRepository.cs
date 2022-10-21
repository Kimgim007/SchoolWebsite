using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class StudentRepository : IRepository<StudentDTO>
    {

        private DataContext _DataContext;

        public StudentRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public async Task Add(StudentDTO student)
        {

             _DataContext.Students.Add((student));
            await _DataContext.SaveChangesAsync();

        }
        public async Task<StudentDTO> Get(int Id)
        {

            var student = await _DataContext.Students
                .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                .Include(_ => _.ScientificWork.Select(t => t.Teacher))
                .Include(_ => _.ScientificWork.Select(t => t.Student))
                .Include(_ => _.ScientificWork.Select(t => t.Subject))
                .FirstOrDefaultAsync(St => St.Id == Id);
            return (student);

        }
        public async Task<List<StudentDTO>> GetAll()
        {
            return await _DataContext.Students
                .Include(s => s.Grades.Select(t => t.Lecture.Teacher))
                .Include(s => s.Grades.Select(t => t.Lecture.Subject))
                .Include(_ => _.ScientificWork)
                .Include(_ => _.ScientificWork.Select(t => t.Teacher))
                .Include(_ => _.ScientificWork.Select(t => t.Student))
                .Include(_ => _.ScientificWork.Select(t => t.Subject)).ToListAsync();
        }
        public async Task Update(StudentDTO student)
        {
            var updateStudent = await _DataContext.Students.FirstOrDefaultAsync(St => St.Id == student.Id);
            if (updateStudent != null)
            {
                updateStudent.Name = student.Name;
                updateStudent.Birthday = student.Birthday;
                updateStudent.Gender = student.Gender;
               await _DataContext.SaveChangesAsync();
            }
        }
        public async Task RemoveStudent(int id)
        {

            var student = await _DataContext.Students.FirstOrDefaultAsync(St => St.Id == id);
            if (student != null)
            {
                 _DataContext.Students.Remove(student);
                await _DataContext.SaveChangesAsync();
            }
        }
    }
}
