
using Microsoft.Extensions.DependencyInjection;
using People.Data.DTO;
using People.Data.Repository;
using People.Data.Repository.Interface;
using People.EfStuff.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data
{
    public static class RegisterDependencies
    {
        public static void Register(IServiceCollection repository)
        {
            repository.AddScoped<DataContext>();     
        }
    }
}
