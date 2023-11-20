using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context, 
                                            ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetSeedOrders());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Domain.Entities.Order> GetSeedOrders()
        {
            return new List<Domain.Entities.Order>
            {
                new Domain.Entities.Order { UserName = "user", FirstName = "Tester", LastName = "Testerson", 
                    Email = "tt@testes.com", Address = "AddressMek", Country = "UK", TotalPrice = 100}
            };
        }
    }
}
