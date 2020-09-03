using System;
using System.Collections.Generic;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
