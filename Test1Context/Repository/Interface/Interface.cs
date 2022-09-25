
using System;
using System.Collections.Generic;
using System.Text;
using Test1Context.DTO;

namespace Test1Context.Repository.Interface
{
    internal interface Interface<T> where T : ObjectDTO
    {
        void Add(T obj);
        List<T> GetAll();
        T Get(int id);  
    }
}
