using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class LectureService : ILectureService
    {
        private LectureRepository repository { get; set; }
        public LectureService(LectureRepository lectureRepository)
        {
            this.repository = lectureRepository;
        }

        public async Task AddLecture(Lecture lecture)
        {
            await this.repository.Add(MapingService.map(lecture));
        }
        public async Task AddLectures(List<Lecture> lectures)
        {
            foreach (Lecture lecture in lectures)
            {
                await this.repository.Add(MapingService.map(lecture));
            }
        }
        public async Task<Lecture> GetLecture(int id)
        {
            return  MapingService.map(await this.repository.Get(id), true);
        }
        public async Task<List<Lecture>> GetLectures()
        {
            var lectures = await this.repository.GetAll();
            return lectures.Select(L => MapingService.map(L, true)).ToList();

        }
        public async Task UpdateLecture(Lecture lecture)
        {
            await this.repository.Update(MapingService.map(lecture));
        }

        //public Lecture GetLastLecture()
        //{
        //    return MapingService.map(this.repository.GetLastLecture(), false);
        //}

        //public DateTime GetMaxTimeLecture()
        //{
        //    return this.repository.GetLectureDatatime();
        //}

    }
}
