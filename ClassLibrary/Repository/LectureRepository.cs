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
        public void Add(LectureDTO lecture)
        {
            using (var Db = new DataContext())
            {
                Db.Lectures.Add(lecture);
                Db.SaveChanges();
            }
        }
        public LectureDTO Get(int Id)
        {
            using (var Db = new DataContext())
            {
                var lectrue = Db.Lectures.Include(_=>_.Teacher).Include(_=>_.Subject).Include(s => s.Grades.Select(t => t.Student)).FirstOrDefault(l => l.Id == Id);
                //ПОДУМАТЬ!
                //Проверить что должно возвращаться если лектуре null
             
                return lectrue;

            }
        }
        public List<LectureDTO> GetAll()
        {
            using (var Db = new DataContext())
            {
                return Db.Lectures.Include(_ => _.Teacher).Include(_ => _.Subject).Include(s => s.Grades.Select(t => t.Student)).ToList();
            }
        }
        public void Update(LectureDTO lecture)
        {
            using (var Db = new DataContext())
            {
                var updateLecture = Db.Lectures.First(Lc => Lc.Id == lecture.Id);
                updateLecture.Subject = lecture.Subject;
                updateLecture.StartTime = lecture.StartTime;
                updateLecture.itemName = lecture.itemName;
                updateLecture.Teacher = (lecture).Teacher;
                Db.SaveChanges();
            }
        }
        public LectureDTO GetLastLecture()
        {
            using (var Db = new DataContext())
            {
                var idLastLecture = Db.Lectures.Max(l => l.Id);
                var lecture = Get(idLastLecture);
                return lecture;
            }
        }
        public DateTime GetLectureDatatime()
        {
            using (var Db = new DataContext())
            {
                var dataTime = Db.Lectures.Max(L => L.StartTime);
                return dataTime;

            }
        }
    }
}
