using Shopping.Models;

namespace Shopping.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>?> GetOrderByUsername(string username);
}