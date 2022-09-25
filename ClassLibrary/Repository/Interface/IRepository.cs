

using People.Data.DTO;
using System.Collections.Generic;

namespace People.Data.Repository.Interface
{
    interface IRepository<T> where T : ObjectDTO
    {
         void Add(T obj);
         T Get(int id);
         List<T> GetAll();
         void Update(T obj);
    

    }
}
