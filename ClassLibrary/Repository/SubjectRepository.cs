using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;

namespace People.Data.Repository
{
    public class SubjectRepository : IRepository<SubjectDTO>
    {

        private DataContext _DataContext;

        public SubjectRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public async Task Add(SubjectDTO subject)
        {
            
                _DataContext.Subjects.Add((subject));
                await _DataContext.SaveChangesAsync();
        
        }
        public async Task<SubjectDTO> Get(int Id)
        {
           
                var subject = await _DataContext.Subjects.FirstOrDefaultAsync(Sb=>Sb.Id == Id);
                return (subject);       
               
        }
        public async Task<List<SubjectDTO>> GetAll()
        {
            
                return await _DataContext.Subjects.ToListAsync();
            
        }
        public async Task Update(SubjectDTO subject)
        {
            var subjectDTO = await _DataContext.Subjects.FirstOrDefaultAsync(s=>s.Id == subject.Id);
            if (subjectDTO != null)
            {
                subjectDTO.Title = subject.Title;
                await _DataContext.SaveChangesAsync();
            }
        }
        public async Task Remove(int id)
        {
            var subject = await _DataContext.Subjects.FirstOrDefaultAsync(s=>s.Id == id);
            if (subject != null)
            {
                _DataContext.Subjects.Remove(subject);
                await _DataContext.SaveChangesAsync();
            }
        }
    }
}
