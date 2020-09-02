using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationContext _context;
        private DbSet<T> entities;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetByID(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public int Insert(T entity)
        {
            entity.Id = entities.Max(e => e == null ? 1 : e.Id+1);
            entities.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(e => e.Id == id);
            entities.Remove(entity);
            _context.SaveChanges();
        }

        
    }
}
