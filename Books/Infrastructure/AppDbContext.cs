using Books.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<BookDb> books { get; set; }
        public DbSet<UserDb> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDb>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)"); 
        }
    }
}
