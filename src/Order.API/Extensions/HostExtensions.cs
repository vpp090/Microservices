using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Order.API.Extensions
{
    public static class HostExtensions
    {
        public static WebApplication MigrateDatabase<TContext>(this WebApplication host,
                                                      Action<TContext, IServiceProvider> seeder,
                                                      int? retry = 0) where TContext : DbContext
                                                           
        {
            int retryForAvailable = retry.Value;
           
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetRequiredService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context: {typeof(DbContext)}");

                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation($"Migrated database with context: {typeof(DbContext)}");
                }
                catch (SqlException ex)
                {
                    logger.LogError($"Error in the migration: {ex}");
                    if(retryForAvailable < 50)
                    {
                        retryForAvailable++;
                        Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, seeder, retryForAvailable);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, 
                                                    TContext context, 
                                                    IServiceProvider services)
            where TContext : DbContext
            
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
