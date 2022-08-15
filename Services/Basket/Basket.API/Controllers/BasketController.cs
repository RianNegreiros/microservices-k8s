using System.Net;
using Basket.API.Entities;
using Basket.API.Grpc.Services;
using Basket.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly DiscountService _discountService;

    public BasketController(IBasketRepository repository, DiscountService discountService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
    }

    [HttpGet("{username}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
        var basket = await _repository.GetBasket(userName);
        return Ok(basket ?? new ShoppingCart(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await _discountService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }
        
        return Ok(await _repository.UpdateBasket(basket));
    }
    
    [HttpDelete("{username}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
    {
        await _repository.DeleteBasket(userName);
        return Ok();
    }
}