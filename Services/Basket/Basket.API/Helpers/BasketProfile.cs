using AutoMapper;
using Basket.API.Entities;
using EventBus.Messages.Events;

namespace Basket.API.Helpers;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
    }
}