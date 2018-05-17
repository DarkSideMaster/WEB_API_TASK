using System;
using System.Collections.Generic;
using Database.Models;

namespace Database.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class 
    {
        List<T> Entities { get;}
        T GetEntity(int id); 
        void Create(T item); 
        void Update(T item);
        void Delete(int id); 
    }
}