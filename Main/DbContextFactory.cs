using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Main
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<MyDbContext>();

            ConfigureDatabaseOptions(optionBuilder);

            return new MyDbContext(optionBuilder.Options);
        }

        public static void ConfigureDatabaseOptions(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("testDatabase");
        }
    }
}