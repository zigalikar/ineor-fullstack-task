using System;
using IneorTaskBackend.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IneorTaskBackend.Helpers
{
    /// <summary>
    /// Helper/extension functions for migrating the database
    /// </summary>
    public static class MigrateHelper
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return host;
        }
    }
}

