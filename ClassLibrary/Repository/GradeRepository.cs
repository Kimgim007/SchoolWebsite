
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
        private DataContext _DataContext;

        public GradeRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(GradeDTO grade)
        {

            _DataContext.Grades.Add(grade);
            _DataContext.SaveChanges();

        }

        public GradeDTO Get(int id)
        {

            var grede = _DataContext.Grades.Include(G => G.Lecture).Include(g => g.Student).FirstOrDefault(g => g.Id == id);
            return grede;

        }

        public List<GradeDTO> GetAll()
        {

            return _DataContext.Grades.Include(G => G.Lecture).Include(g => g.Student).ToList();

        }

        public void Update(GradeDTO gradeDTO)
        {

            var Grade = _DataContext.Grades.First(Gr => Gr.Id == gradeDTO.Id);
            Grade.Value = gradeDTO.Value;
            Grade.Student = gradeDTO.Student;
            Grade.Lecture = gradeDTO.Lecture;
            _DataContext.SaveChanges();

        }
    }
}
