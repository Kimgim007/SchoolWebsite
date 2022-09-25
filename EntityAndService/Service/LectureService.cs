using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.EntityAndService.Service
{
    public class LectureService
    {
        private LectureRepository repository { get; set; }
        public LectureService(LectureRepository lectureRepository)
        {
            this.repository = lectureRepository;
        }
        public DateTime GetMaxTimeLecture()
        {
            return this.repository.GetLectureDatatime();
        }
        public void AddLecture(Lecture lecture)
        {
            this.repository.Add(MapingService.map(lecture));
        }
        public void AddLectures(List<Lecture> lectures)
        {
            foreach (Lecture lecture in lectures)
            {
                this.repository.Add(MapingService.map(lecture));
            }
        }
        public List<Lecture> GetLectures()
        {

            return this.repository.GetAll().Select(L => MapingService.map(L, true)).ToList();

        }
        public Lecture GetLecture(int id)
        {

            return MapingService.map(this.repository.Get(id), true);
        }
        public Lecture GetLastLecture()
        {
            return MapingService.map(this.repository.GetLastLecture(), false);
        }
        public void UpdateLecture(Lecture lecture)
        {
            this.repository.Update(MapingService.map(lecture));
        }
    }
}
