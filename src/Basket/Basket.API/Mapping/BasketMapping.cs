using AutoMapper;
using Basket.API.Entities;
using EventBus.RabbitMQ.Events;

namespace Basket.API.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
