using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class SubjectService : ISubjectService
    {
        private SubjectRepository repository { get; set; }

        public SubjectService(SubjectRepository subjectRepository)
        {
            this.repository = subjectRepository;
        }
        public async Task AddSubject(Subject title)
        {
            await this.repository.Add(MapingService.map(title));
        }
        public async Task<Subject> GetSubject(int Id)
        {
            return MapingService.map(await repository.Get(Id));
        }
        public async Task<List<Subject>> GetSubjects()
        {
            var subjects = await this.repository.GetAll();
            return subjects.Select(MapingService.map).ToList();
        }
    }
}
