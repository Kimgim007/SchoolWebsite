using Data.DTO;
using People.EfStuff.Db;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using People.Data.Repository.Interface;

namespace People.Data.Repository
{
    public class ScientificWorkRepository : IRepository<ScientificWorkDTO>
    {
        public void Add(ScientificWorkDTO scientificWork)
        {
            using (var Db = new DataContext())
            {
                Db.ScientificWorks.Add(scientificWork);
                Db.SaveChanges();
            }
        }
        public ScientificWorkDTO Get(int Id)
        {
            using(var Db = new DataContext())
            {
                var ScientificWork = Db.ScientificWorks.Include(_=>_.Subject).Include(_=>_.Teacher).Include(_=>_.Student).FirstOrDefault(x => x.Id == Id);
                return ScientificWork;
            }
        }
        public List<ScientificWorkDTO> GetAll()
        {
            using(var Db = new DataContext())
            {
                return Db.ScientificWorks.Include(_ => _.Subject).Include(_ => _.Teacher).Include(_ => _.Student).ToList();
            }
        }

        public void Update(ScientificWorkDTO obj)
        {
            using(var Db = new DataContext())
            {
                var updateScientificWork = Db.ScientificWorks.First(_ => _.Id == obj.Id);
                updateScientificWork.Title = obj.Title;
                updateScientificWork.Subject = obj.Subject;
                updateScientificWork.Student = obj.Student;
                updateScientificWork.Teacher = obj.Teacher;
                Db.SaveChanges();
             
            }
        }
    }
}
