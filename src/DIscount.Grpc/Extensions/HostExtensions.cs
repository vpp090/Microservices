using Npgsql;

namespace Discount.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static WebApplication MigrateDatabase<TContext>(this WebApplication host, int? retry = 0)
        {
            int retryAvailability = retry.Value;

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider; 
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postgresql database");

                    using var connection = 
                        new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS Coupon";

                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                                     ProductName VARCHAR(24) NOT NULL,
                                                                     Description TEXT,
                                                                     Amount INT)";

                   command.ExecuteNonQuery();

                   command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES ('IPhone X','IPhone Discount', 150);";
                   command.ExecuteNonQuery();

                   command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES ('Samsung Z', 'Samsung Discount', 230);";
                   command.ExecuteNonQuery();

                    logger.LogInformation("Migrated postgresql databases");
                }
                catch(NpgsqlException ex)
                {
                    if(retryAvailability < 50)
                    {
                        retryAvailability++;
                        Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryAvailability);
                    }
                }
            }

            return host;
        }
    }
}
