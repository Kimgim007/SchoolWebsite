using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.EfStuff.Db;
using People.Data.Repository.Interface;

namespace People.Data.Repository
{
    public class LectureRepository : IRepository<LectureDTO>
    {
        private DataContext _DataContext;

        public LectureRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public void Add(LectureDTO lecture)
        {

            _DataContext.Lectures.Add(lecture);
            _DataContext.SaveChanges();

        }
        public LectureDTO Get(int Id)
        {

            var lectrue = _DataContext.Lectures.Include(_ => _.Teacher).Include(_ => _.Subject).Include(s => s.Grades.Select(t => t.Student)).FirstOrDefault(l => l.Id == Id);
            //ПОДУМАТЬ!
            //Проверить что должно возвращаться если лектуре null

            return lectrue;


        }
        public List<LectureDTO> GetAll()
        {

            return _DataContext.Lectures.Include(_ => _.Teacher).Include(_ => _.Subject).Include(s => s.Grades.Select(t => t.Student)).ToList();

        }
        public void Update(LectureDTO lecture)
        {

            var updateLecture = _DataContext.Lectures.First(Lc => Lc.Id == lecture.Id);
            updateLecture.Subject = lecture.Subject;
            updateLecture.StartTime = lecture.StartTime;
            updateLecture.itemName = lecture.itemName;
            updateLecture.Teacher = (lecture).Teacher;
            _DataContext.SaveChanges();

        }
        public LectureDTO GetLastLecture()
        {

            var idLastLecture = _DataContext.Lectures.Max(l => l.Id);
            var lecture = Get(idLastLecture);
            return lecture;

        }
        public DateTime GetLectureDatatime()
        {

            var dataTime = _DataContext.Lectures.Max(L => L.StartTime);
            return dataTime;


        }
    }
}
