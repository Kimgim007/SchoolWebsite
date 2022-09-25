using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;

namespace People.EntityAndService.Service
{
    public class SubjectService
    {
        private SubjectRepository repository {get;set;}
       
        public SubjectService(SubjectRepository subjectRepository)
        {
            this.repository = subjectRepository;
        }
        public void AddSubject(Subject title)
        {
            this.repository.Add(MapingService.map(title));
        }
        public Subject GetSubject(int Id)
        {
           return MapingService.map(repository.Get(Id));
        }
        public List<Subject> GetSubjects()
        {
            return this.repository.GetAll().Select(MapingService.map).ToList();
        }
    }
}
