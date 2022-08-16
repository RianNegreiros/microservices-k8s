namespace Shopping.Aggregator.Models;

public class ShoppingModel
{
    public string Username { get; set; }
    public BasketModel BasketWithProducts { get; set; }
    public IEnumerable<OrderResponseModel> Orders { get; set; }
}