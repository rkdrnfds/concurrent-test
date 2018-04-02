using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(1024, 1024);

            NLog.LogManager.LoadConfiguration(String.Join("/", Directory.GetCurrentDirectory(), "nlog.config"));


            var host = new WebHostBuilder()
                .UseUrls("http://*:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseKestrel(o =>
                {
//                        o.Limits.MaxConcurrentConnections = 8;
                })
                .UseNLog()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}