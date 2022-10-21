using People.EntityAndService.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface ILectureService
    {
        Task AddLecture(Lecture lecture);
        Task AddLectures(List<Lecture> lectures);
        Task<Lecture> GetLecture(int id);
        Task<List<Lecture>> GetLectures();
        Task UpdateLecture(Lecture lecture);

        //DateTime GetMaxTimeLecture();
        //Lecture GetLastLecture();
    }
}