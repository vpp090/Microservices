using AutoMapper;
using Basket.API.Entities;
using Basket.API.Repositories;
using BrokerMessagesR.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public BasketController(IBasketRepository repository, IMapper mapper, IPublishEndpoint endpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = endpoint;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingBasket>> GetBasket(string username)
        {
            var basket = await _repository.GetBasket(username);

            if (basket == null)
                return NotFound();

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingBasket>> CreateBasket(string username, ShoppingBasket basket)
        {
            var result = await _repository.CreateBasket(username, basket);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ShoppingBasket>> UpdateBasket([FromBody] ShoppingBasket basket)
        {
            var result = await _repository.UpdateBasket(basket);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string userName)
        {
            var result = await _repository.DeleteBasket(userName);

            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CheckoutEvent checkoutEvent)
        {
            var basket = await _repository.GetBasket(checkoutEvent.Checkout.UserName);
            if (basket == null) return BadRequest();

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(checkoutEvent);
            eventMessage.Order.TotalPrice = basket.TotalPrice;

            await _publishEndpoint.Publish(eventMessage);

            await _repository.DeleteBasket(basket.Username);

            return Ok(basket);
        }
    }
}
