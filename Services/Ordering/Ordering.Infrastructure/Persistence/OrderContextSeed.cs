using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetPreconfiguredOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", nameof(OrderContext));
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
            new() {Username = "swn", FirstName = "firstname", LastName = "lastname", Email = "riannegreiros@dev", Address = "Rio", Country = "Brazil", State = "Rio de Janeiro", ZipCode = "999999", TotalPrice = 999, CardName = "cardName", CardNumber = "cardNumber", Expiration = "expiration", CVV = "123", PaymentMethod = 1, LastModifiedBy = DateTime.UtcNow.ToString()}
        };
    }
}