using System;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Photos = new PhotoRepository(_context);
        }

        public IGenericRepository<User> Users { get; private set; }

        public IGenericRepository<Photo> Photos { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
