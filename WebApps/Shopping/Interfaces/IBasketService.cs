using Shopping.Models;

namespace Shopping.Interfaces;

public interface IBasketService
{
    Task<BasketModel?> GetBasket(string username);
    Task<BasketModel?> UpdateBasket(BasketModel model);
    Task DeleteBasket(BasketCheckoutModel model);
    Task CheckoutBasket(BasketCheckoutModel model);
}