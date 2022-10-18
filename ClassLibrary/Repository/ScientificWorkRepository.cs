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

        private DataContext _DataContext;

        public ScientificWorkRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(ScientificWorkDTO scientificWork)
        {

            _DataContext.ScientificWorks.Add(scientificWork);
            _DataContext.SaveChanges();

        }
        public ScientificWorkDTO Get(int Id)
        {

            var ScientificWork = _DataContext.ScientificWorks.Include(_ => _.Subject).Include(_ => _.Teacher).Include(_ => _.Student).FirstOrDefault(x => x.Id == Id);
            return ScientificWork;

        }
        public List<ScientificWorkDTO> GetAll()
        {

            return _DataContext.ScientificWorks.Include(_ => _.Subject).Include(_ => _.Teacher).Include(_ => _.Student).ToList();

        }

        public void Update(ScientificWorkDTO obj)
        {

            var updateScientificWork = _DataContext.ScientificWorks.First(_ => _.Id == obj.Id);
            updateScientificWork.Title = obj.Title;
            updateScientificWork.Subject = obj.Subject;
            updateScientificWork.Student = obj.Student;
            updateScientificWork.Teacher = obj.Teacher;
            _DataContext.SaveChanges();


        }
    }
}
