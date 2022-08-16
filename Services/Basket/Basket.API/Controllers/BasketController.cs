using System.Net;
using AutoMapper;
using Basket.API.Entities;
using Basket.API.Grpc.Services;
using Basket.API.Interfaces;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly DiscountService _discountService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public BasketController(IBasketRepository repository, DiscountService discountService, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
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

    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        var basket = await _repository.GetBasket(basketCheckout.Username);
        if (basket == null)
        {
            return BadRequest();
        }

        var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
        eventMessage.TotalPrice = basket.TotalPrice;
        await _publishEndpoint.Publish(eventMessage);
        
        await _repository.DeleteBasket(basket.UserName);

        return Accepted();
    }
}