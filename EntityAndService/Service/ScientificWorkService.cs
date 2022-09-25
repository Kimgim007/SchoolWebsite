using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;

namespace People.EntityAndService.Service
{
    public class ScientificWorkService
    {
        private ScientificWorkRepository repository { get; set; }
        public ScientificWorkService(ScientificWorkRepository scientificWorkRepository)
        {
            this.repository = scientificWorkRepository;
        }
        public void AddScientificWork(ScientificWork scientificWork)
        {
            repository.Add(MapingService.map(scientificWork));
        }
        public List<ScientificWork> GetScientificWorks()
        {
            return repository.GetAll().Select(s=>MapingService.map(s,true)).ToList();
        }
        public ScientificWork GetScientificWork(int id)
        {
            return MapingService.map(this.repository.Get(id),true);
        }
        public void Update(ScientificWork scientificWork)
        {
            this.repository.Update(MapingService.map(scientificWork));
        }
    }
}
