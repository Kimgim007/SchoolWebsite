using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;

namespace People.Data.Repository
{
    public class SubjectRepository : IRepository<SubjectDTO>
    {

        private DataContext _DataContext;

        public SubjectRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(SubjectDTO subject)
        {
            
                _DataContext.Subjects.Add((subject));
                _DataContext.SaveChanges();
            
        }
        public SubjectDTO Get(int Id)
        {
           
                var subject = _DataContext.Subjects.FirstOrDefault(Sb=>Sb.Id == Id);
                return (subject);       
               
        }
        public List<SubjectDTO> GetAll()
        {
            
                return _DataContext.Subjects.ToList();
            
        }

        public void Update(SubjectDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
