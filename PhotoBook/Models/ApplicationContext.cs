using Microsoft.EntityFrameworkCore;
using PhotoBook.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }
}