using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "wes",
                    FirstName = "Wesley",
                    LastName = "Canosa",
                    EmailAddress= "wesley.canosa@gmail.com",
                    AddressLine = "Rua São Francisco, 156",
                    Country = "Brazil",
                    ZipCode = "16400-540",
                    TotalPrice = 350
                }
            };
        }
    }
}
