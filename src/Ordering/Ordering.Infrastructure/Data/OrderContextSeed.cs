using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0) 
        {
            int retryForAvailability = retry.Value;

            try
            {
                // INFO: Run this if using a real database. Used to automatically migrate docker image of sql server db.
                orderContext.Database.Migrate();
                // orderContext.Database.EnsureCreated();

                if (!orderContext.Orders.Any()) 
                {
                    orderContext.Orders.AddRange(GetPreConfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch(Exception exception) 
            {
                if(retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }

                throw;
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>() 
            {
                new Order() { UserName = "swn", FirstName = "Muhammad", LastName = "Aziz", EmailAddress = "aziz@gmail.com", AddressLine = "Karachi", TotalPrice = 5239 },
                new Order() { UserName = "swn", FirstName = "Muhammad", LastName = "Imad", EmailAddress ="imad@gmail.com", AddressLine = "Karachi", TotalPrice = 3486 }
            };
        }
    }
}
