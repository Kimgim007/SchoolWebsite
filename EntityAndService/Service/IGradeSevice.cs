using People.EntityAndService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface IGradeSevice
    {
        Task AddGrade(Grade grade);
        Task<Grade> Get(int id);
        Task<List<Grade>> GetAll();
        Task Update(Grade grade);
    }
}