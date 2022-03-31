using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Model
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        
    }
}
