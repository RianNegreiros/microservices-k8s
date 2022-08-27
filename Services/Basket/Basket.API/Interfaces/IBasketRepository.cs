using Basket.API.Entities;

namespace Basket.API.Interfaces;

public interface IBasketRepository
{
    Task<ShoppingCart?> GetBasket(string userNname);
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
    Task DeleteBasket(string username);
}