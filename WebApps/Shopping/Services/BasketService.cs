using Shopping.Extensions;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient _client;

    public BasketService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<BasketModel?> GetBasket(string username)
    {
        var response = await _client.GetAsync($"/Basket/{username}");
        return await response.ReadContentAs<BasketModel>();
    }

    public async Task<BasketModel?> UpdateBasket(BasketModel model)
    {
        var response = await _client.PostAsJson($"/Basket", model);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<BasketModel>();
        
        throw new Exception("Something went wrong when calling api.");
    }

    public async Task DeleteBasket(BasketCheckoutModel model)
    {
        var response = await _client.PostAsJson($"/Basket/Checkout", model);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong when calling api.");
    }
    
    public async Task CheckoutBasket(BasketCheckoutModel model)
    {
        var response = await _client.PostAsJson($"/Basket/Checkout", model);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Something went wrong when calling api.");
        }
    }
}