using System;
using System.Net;
using IneorTaskBackend.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IneorTaskBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry((o) =>
                    {
                        o.Dsn = "https://3e5033c826ce418f8ad0573504895809@o1356861.ingest.sentry.io/6642715";
                        o.Debug = true;
                        o.TracesSampleRate = 1.0;
                    });

                    var port = Environment.GetEnvironmentVariable("PORT");
                    webBuilder.UseKestrel((o) => o.ListenAnyIP(Int32.Parse(port)));
                    webBuilder.UseUrls($"http://*:{port}");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
