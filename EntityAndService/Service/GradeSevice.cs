using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class GradeSevice : IGradeSevice
    {
        private GradeRepository repository { get; set; }
        public GradeSevice(GradeRepository gradeRepository)
        {
            this.repository = gradeRepository;
        }

        public async Task AddGrade(Grade grade)
        {
            await this.repository.Add(MapingService.map(grade, true));
        }
        public async Task<Grade> Get(int id)
        {
            return MapingService.map(await this.repository.Get(id), false);
        }
        public async Task<List<Grade>> GetAll()
        {
            var grades = await this.repository.GetAll();
            return grades.Select(G => MapingService.map(G, true)).ToList();
        }
        public async Task Update(Grade grade)
        {
            await this.repository.Update(MapingService.map(grade, false));
        }

    }
}
