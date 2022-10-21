using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using People.Data.DTO;
using People.EfStuff.Db;
using People.Data.Repository.Interface;
using System.Threading.Tasks;

namespace People.Data.Repository
{
    public class LectureRepository : IRepository<LectureDTO>
    {
        private DataContext _DataContext;

        public LectureRepository(DataContext DataContext)
        {
            this._DataContext = DataContext;
        }

        public async Task Add(LectureDTO lecture)
        {

            _DataContext.Lectures.Add(lecture);
            await _DataContext.SaveChangesAsync();

        }
        public async Task<LectureDTO> Get(int Id)
        {
            var lectrue = await _DataContext.Lectures
                .Include(_ => _.Teacher)
                .Include(_ => _.Subject)
                .Include(s => s.Grades
                .Select(t => t.Student))
                .FirstOrDefaultAsync(l => l.Id == Id);
           
            return lectrue;

        }
        public async Task<List<LectureDTO>> GetAll()
        {
            return await _DataContext.Lectures
                .Include(_ => _.Teacher)
                .Include(_ => _.Subject)
                .Include(s => s.Grades.
                Select(t => t.Student)).ToListAsync();

        }
        public async Task Update(LectureDTO lecture)
        {

            var updateLecture = await _DataContext.Lectures.FirstOrDefaultAsync(Lc => Lc.Id == lecture.Id);
            updateLecture.Subject = lecture.Subject;
            updateLecture.StartTime = lecture.StartTime;
            updateLecture.itemName = lecture.itemName;
            updateLecture.Teacher = (lecture).Teacher;
            await _DataContext.SaveChangesAsync();

        }
        public async Task<LectureDTO> GetLastLecture()
        {

            var idLastLecture = await _DataContext.Lectures.MaxAsync(l => l.Id);
            var lecture = await Get(idLastLecture);
            return lecture;

        }
        public async Task<DateTime> GetLectureDatatime()
        {
            var dataTime = await _DataContext.Lectures.MaxAsync(L => L.StartTime);
            return dataTime;
        }
    }
}
