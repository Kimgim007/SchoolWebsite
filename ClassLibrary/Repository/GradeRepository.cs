
using System;
using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System.Data.Entity;

namespace People.Data.Repository
{
    public class GradeRepository : IRepository<GradeDTO>
    {
        public void Add(GradeDTO grade)
        {
            using (var Db = new DataContext())
            {
                Db.Grades.Add(grade);
                Db.SaveChanges();
            }
        }

        public GradeDTO Get(int id)
        {
            using(var Db = new DataContext())
            {
                var grede = Db.Grades.Include(G => G.Lecture).Include(g => g.Student).FirstOrDefault(g => g.Id == id);
                return grede;
            }
        }

        public List<GradeDTO> GetAll()
        {
            using(var Db =new DataContext())
            {
                return Db.Grades.Include(G=>G.Lecture).Include(g=>g.Student).ToList();
            }
        }

        public void Update(GradeDTO gradeDTO)
        {
           using(var Db = new DataContext())
            {
                var Grade = Db.Grades.First(Gr => Gr.Id == gradeDTO.Id);
                Grade.Value = gradeDTO.Value;
                Grade.Student = gradeDTO.Student;
                Grade.Lecture = gradeDTO.Lecture;
                Db.SaveChanges();
            }
        }
    }
}
