using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
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
        public async Task<ActionResult<ShoppingBasket>> UpdateBasket(string username)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string userName)
        {
            var result = await _repository.DeleteBasket(userName);

            return Ok(result);
        }
    }
}
