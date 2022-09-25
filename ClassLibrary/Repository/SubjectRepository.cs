using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;

namespace People.Data.Repository
{
    public class SubjectRepository : IRepository<SubjectDTO>
    {
        public void Add(SubjectDTO subject)
        {
            using(var Db = new DataContext())
            {
                Db.Subjects.Add((subject));
                Db.SaveChanges();
            }
        }
        public SubjectDTO Get(int Id)
        {
            using (var Db = new DataContext())
            {
                var subject = Db.Subjects.FirstOrDefault(Sb=>Sb.Id == Id);
                return (subject);       
            }   
        }
        public List<SubjectDTO> GetAll()
        {
            using(var db = new DataContext())
            {
                return db.Subjects.ToList();
            }
        }

        public void Update(SubjectDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
