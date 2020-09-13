using Microsoft.EntityFrameworkCore;
using Whoisvisiting.Domain.Entities;

namespace Whoisvisiting.SqlDataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(
                u =>
                {
                    u.Property("Id");
                    u.HasKey("Id");
                });
        }
    }
}
