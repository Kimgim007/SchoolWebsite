
using System;
using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class GradeRepository : IRepository<GradeDTO>
    {
        private DataContext _DataContext;

        public GradeRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }
  
        public async Task Add(GradeDTO grade)
        {

            _DataContext.Grades.Add(grade);
            await _DataContext.SaveChangesAsync();

        }

        public async Task<GradeDTO> Get(int id)
        {

            var grede = await _DataContext.Grades
                .Include(G => G.Lecture)
                .Include(g => g.Student)
                .FirstOrDefaultAsync(g => g.Id == id);
            return grede;

        }

        public async Task<List<GradeDTO>> GetAll()
        {

            return await _DataContext.Grades
                .Include(G => G.Lecture)
                .Include(g => g.Student)
                .ToListAsync();

        }

        public async Task Update(GradeDTO gradeDTO)
        {

            var Grade = await _DataContext.Grades.FirstOrDefaultAsync(Gr => Gr.Id == gradeDTO.Id);
            Grade.Value = gradeDTO.Value;
            Grade.Student = gradeDTO.Student;
            Grade.Lecture = gradeDTO.Lecture;
            await _DataContext.SaveChangesAsync();

        }
    }
}
