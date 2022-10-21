using People.EntityAndService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface ISubjectService
    {
        Task AddSubject(Subject title);
        Task<Subject> GetSubject(int Id);
        Task<List<Subject>> GetSubjects();
    }
}