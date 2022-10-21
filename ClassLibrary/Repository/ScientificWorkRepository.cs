using Data.DTO;
using People.EfStuff.Db;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using People.Data.Repository.Interface;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class ScientificWorkRepository : IRepository<ScientificWorkDTO>
    {

        private DataContext _DataContext;

        public ScientificWorkRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public async Task Add(ScientificWorkDTO scientificWork)
        {

            _DataContext.ScientificWorks.Add(scientificWork);
            await _DataContext.SaveChangesAsync();

        }
        public async Task<ScientificWorkDTO> Get(int Id)
        {

            var ScientificWork = await _DataContext.ScientificWorks
                .Include(_ => _.Subject)
                .Include(_ => _.Teacher)
                .Include(_ => _.Student)
                .FirstOrDefaultAsync(x => x.Id == Id);
            return ScientificWork;

        }
        public async Task<List<ScientificWorkDTO>> GetAll()
        {
            return await _DataContext.ScientificWorks
                .Include(_ => _.Subject)
                .Include(_ => _.Teacher)
                .Include(_ => _.Student).ToListAsync();
        }

        public async Task Update(ScientificWorkDTO obj)
        {
            var updateScientificWork = await _DataContext.ScientificWorks.FirstAsync(_ => _.Id == obj.Id);
            updateScientificWork.Title = obj.Title;
            updateScientificWork.Subject = obj.Subject;
            updateScientificWork.Student = obj.Student;
            updateScientificWork.Teacher = obj.Teacher;
            await _DataContext.SaveChangesAsync();

        }
    }
}
