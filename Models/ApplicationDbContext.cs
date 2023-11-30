using Microsoft.EntityFrameworkCore;

namespace Atelier_2.Models
{
    public class ApplicationdbContext : DbContext
    {
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre> genres { get; set; }

        public DbSet<Customer> customers { get; set; }


        public ApplicationdbContext(DbContextOptions options)
        : base(options)
        {
        }

    }
}
