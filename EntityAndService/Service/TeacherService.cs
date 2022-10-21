using People.Data.Repository;
using People.EntityAndService.Entity;
using People.EntityAndService.Service.Maping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public class TeacherService : ITeacherService
    {
        private TeacherRepository Repository { get; set; }
        public TeacherService(TeacherRepository teacherRepository)
        {
            this.Repository = teacherRepository;
        }
        public async Task AddTeacher(Teacher teacher)
        {
            await this.Repository.Add(MapingService.map(teacher));
        }
        public async Task AddTeachers(List<Teacher> teachers)
        {
            foreach (Teacher teacher in teachers)
            {
                await this.Repository.Add(MapingService.map(teacher));
            }
        }
        public async Task UpdateTeacher(Teacher teacher)
        {
            await this.Repository.Update(MapingService.map(teacher));

        }
        public async Task<Teacher> GetTeacher(int id)
        {
            return MapingService.map(await this.Repository.Get(id), true);
        }
        public async Task<List<Teacher>> GetTeachers()
        {
            var teachers = await this.Repository.GetAll();
            return teachers.Select(t => MapingService.map(t, true)).ToList();

        }
        //public bool AreAllTeachersOver30()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t,false));
        //    bool AllTeaher30 = teachers.All(th => th.Age() > 30);

        //    return AllTeaher30;

        //}
        //public bool AreThereAnyTeachersUnder30()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    bool youngerTheacher30 = teachers.Any(th => th.Age() < 30);

        //        return youngerTheacher30;


        //}
        //public bool IsThereATeacherWhoIs30YearsOldExactly()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    bool theacher30 = teachers.Any(th => th.Age() == 30);

        //        return theacher30;

        //}
        //public int NumberOfTeachersWhoAreFrom30To35()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    int howMachTeshers30_35 = teachers.Count(th => (th.Age() >= 30 && th.Age() <= 35));
        //    return howMachTeshers30_35;
        //}
        //public Teacher TheFirstTeacherWhoIsOver30YearsOld()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    return (teachers.First(th => th.Age() > 30));
        //}
        //public List<IGrouping<int, Teacher>> GroupTeachersByAge()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    var grupp = teachers.GroupBy(th => th.Age()).OrderBy(g => g.Key).ToList();

        //    return grupp;
        //}
        //public Teacher TheLastTeacherWhoIs30YearsOld()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));  
        //    return teachers.LastOrDefault(th => th.Age() == 30);
        //}
        //public List<Teacher> OutputOfTheListOfTeachersSkippingTheFirst5()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    var teshersGrup =  teachers.Skip(5).ToList();
        //    return teshersGrup;

        //}
        //public List<Teacher> EnterFirstFiveTeachers()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    var teshersGrup =  teachers.Take(5).ToList();

        //    return teshersGrup;
        //}
        //public List<IGrouping<int,Teacher>> GrupTeachersByMoth()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    var groppStudenForFirsWord = teachers.GroupBy(th => th.Birthday.Month).OrderBy(th => th.Key).ToList();


        //    return (groppStudenForFirsWord);
        //}
        //public List<IGrouping<char, Teacher>> GrupTeachersByFirstZP()
        //{
        //    var teachers = Repository.GetAll().Select(t=>MapingService.map(t, false));
        //    var gruppTheachersZP = teachers.GroupBy(th => th.ZP.ToString()[0]).OrderBy(th => th.Key).ToList();


        //    return (gruppTheachersZP);
        //}
    }
}
