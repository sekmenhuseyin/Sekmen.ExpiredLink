using Microsoft.EntityFrameworkCore;
using Sekmen.ExpiredLink.Database.Entity;

namespace Sekmen.ExpiredLink.Database
{
    public class ExpiredLinkContext : DbContext
    {
        public ExpiredLinkContext(DbContextOptions<ExpiredLinkContext> options) : base(options)
        {
        }

        public DbSet<LinksTable> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinksTable>().ToTable("Links");
        }
    }
}
