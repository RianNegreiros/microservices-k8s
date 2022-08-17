using Shopping.Extensions;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;

    public OrderService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<IEnumerable<OrderResponseModel>?> GetOrderByUsername(string username)
    {
        var response = await _client.GetAsync($"/Order/{username}");
        return await response.ReadContentAs<List<OrderResponseModel>>();
    }
}