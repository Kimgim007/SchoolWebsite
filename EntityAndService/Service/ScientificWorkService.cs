using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class ScientificWorkService : IScientificWorkService
    {
        private ScientificWorkRepository repository { get; set; }
        public ScientificWorkService(ScientificWorkRepository scientificWorkRepository)
        {
            this.repository = scientificWorkRepository;
        }
        public async Task AddScientificWork(ScientificWork scientificWork)
        {
            await repository.Add(MapingService.map(scientificWork));
        }
        public async Task<List<ScientificWork>> GetScientificWorks()
        {
            var scientificWorks = await repository.GetAll();
            return scientificWorks.Select(s => MapingService.map(s, true)).ToList();
        }
        public async Task<ScientificWork> GetScientificWork(int id)
        {
            return MapingService.map(await this.repository.Get(id), true);
        }
        public async Task Update(ScientificWork scientificWork)
        {
            await this.repository.Update(MapingService.map(scientificWork));
        }
    }
}
