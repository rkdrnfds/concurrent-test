using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Main
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MyDbContext>(DbContextFactory.ConfigureDatabaseOptions);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
//            loggerFactory.AddConsole(LogLevel.Information);
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}