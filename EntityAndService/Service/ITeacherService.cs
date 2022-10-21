using People.EntityAndService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.EntityAndService.Service
{
    public interface ITeacherService
    {
        Task AddTeacher(Teacher teacher);
        Task AddTeachers(List<Teacher> teachers);
        Task<Teacher> GetTeacher(int id);
        Task<List<Teacher>> GetTeachers();
        Task UpdateTeacher(Teacher teacher);
    }
}