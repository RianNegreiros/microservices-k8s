using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Interfaces;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;

    public OrderService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<OrderResponseModel>?> GetOrdersByUsername(string username)
    {
        var response = await _client.GetAsync($"/api/v1/Order/{username}");
        return await response.ReadContent<List<OrderResponseModel>>();
    }
}