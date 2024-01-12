using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Mapper;
using Basket.API.Repositories;
using BrokerMessagesR.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly DiscountGrpcService _discountService;
        private readonly ILogger<BasketController> _logger;
        private readonly IConfiguration _config;

        public BasketController(IBasketRepository repository, IMapper mapper,
                IPublishEndpoint endpoint,
                DiscountGrpcService service,
                ILogger<BasketController> logger,
                IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = endpoint;
            _discountService = service;
            _logger = logger;
            _config = config;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(typeof(ShoppingBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasket>> GetBasket(string username)
        {
            var basket = await _repository.GetBasket(username);

            if (basket == null)
                return NotFound();

            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasket>> CreateBasket(string username, ShoppingBasket basket)
        {
            _logger.LogInformation(_config["GrpcSettings:DiscountUrl"]);

            var result = await _repository.CreateBasket(username, basket);

            foreach (var item in basket.Items)
            {
                var coupon = await _discountService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShoppingBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasket>> UpdateBasket([FromBody] ShoppingBasket basket)
        {

            foreach(var item in basket.Items)
            {
                var coupon = await _discountService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            var result = await _repository.UpdateBasket(basket);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteBasket(string userName)
        {
            var result = await _repository.DeleteBasket(userName);

            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] CheckoutEvent checkoutEvent, [FromServices]ISpecialMapperR specMap)
        {
            var basket = await _repository.GetBasket(checkoutEvent.Checkout.UserName);
            if (basket == null) return NotFound("Basket_Not_Found");

            var eventMessage = new BasketCheckoutEvent();

            eventMessage.Order = specMap.MapProperties(checkoutEvent.Checkout, eventMessage.Order);
            eventMessage.Order.TotalPrice = basket.TotalPrice;

            await _publishEndpoint.Publish(eventMessage);

            await _repository.DeleteBasket(basket.Username);

            return Ok(basket);
        }
    }
}
