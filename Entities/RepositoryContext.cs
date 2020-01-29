using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<User> User { get; set; }
    }
}