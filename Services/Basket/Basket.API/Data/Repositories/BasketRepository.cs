using Basket.API.Entities;
using Basket.API.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Data.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
    }

    public async Task<ShoppingCart?> GetBasket(string username)
    {
        var basket = await _redisCache.GetStringAsync(username);

        if (String.IsNullOrEmpty(basket)) return null;

        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

        return await GetBasket(basket.Username);
    }

    public async Task DeleteBasket(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}