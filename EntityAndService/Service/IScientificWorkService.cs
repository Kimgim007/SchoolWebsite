using People.EntityAndService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface IScientificWorkService
    {
        Task AddScientificWork(ScientificWork scientificWork);
        Task<ScientificWork> GetScientificWork(int id);
        Task<List<ScientificWork>> GetScientificWorks();
        Task Update(ScientificWork scientificWork);
    }
}