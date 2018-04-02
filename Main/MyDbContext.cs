using Microsoft.EntityFrameworkCore;

namespace Main
{
    public class MyDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasKey(b => b.Key);

            modelBuilder.Entity<Blog>().SeedData(
                new {Key = 1, Desc = "First"},
                new {Key = 2, Desc = "Second"}
            );
        }
    }
}