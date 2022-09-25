using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;

namespace People.EntityAndService.Service
{
    public class GradeSevice
    {
        private GradeRepository repository { get; set; }
        public GradeSevice(GradeRepository gradeRepository)
        {
            this.repository = gradeRepository;
        }
   
        public void AddGrade(Grade grade)
        {
            this.repository.Add(MapingService.map(grade, true));
        }
        public Grade Get(int id)
        {
            return MapingService.map(this.repository.Get(id),false);
        }
        public List<Grade> GetAll()
        {
            return this.repository.GetAll().Select(G=>MapingService.map(G,true)).ToList();
        }
        public void Update(Grade grade)
        {
           this.repository.Update(MapingService.map(grade,false));
        }

    }
}
