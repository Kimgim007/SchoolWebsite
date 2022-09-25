using Microsoft.Extensions.DependencyInjection;
using People.Data.Repository;
using People.EntityAndService.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAndService
{
    public static class RegisterDependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ScientificWorkRepository>(x => new ScientificWorkRepository());
            services.AddScoped<LectureRepository>(x => new LectureRepository());
            services.AddScoped<StudentRepository>(x => new StudentRepository());
            services.AddScoped<TeacherRepository>(x=> new TeacherRepository());

            services.AddScoped<GradeRepository>(x => new GradeRepository());
            services.AddScoped<SubjectRepository>(x => new SubjectRepository());
        }
    }
}
