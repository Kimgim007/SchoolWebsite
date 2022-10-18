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
            People.Data.RegisterDependencies.Register(services);

            services.AddScoped<ScientificWorkRepository>();
            services.AddScoped<LectureRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<TeacherRepository>();

            services.AddScoped<GradeRepository>();
            services.AddScoped<SubjectRepository>();
        }
    }
}
