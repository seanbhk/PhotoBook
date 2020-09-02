using System;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Photo> Photos { get; }

        int Complete();
    }
}
