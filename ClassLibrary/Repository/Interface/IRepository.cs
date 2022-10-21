

using People.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Data.Repository.Interface
{
    interface IRepository<T> where T : ObjectDTO
    {
         Task Add(T obj);
         Task<T> Get(int id);
         Task<List<T>> GetAll();
         Task Update(T obj);
    

    }
}
