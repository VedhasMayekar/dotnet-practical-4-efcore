using Microsoft.EntityFrameworkCore;
using pract4_97.Database.Entities;
namespace pract4_97.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
    }
}
