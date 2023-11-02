using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {

        public OrderingController()
        {
            
        }

        [HttpGet]
        public async Task<ActionResult> GetOrder()
        {
            throw new NotFiniteNumberException();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder()
        {
            throw new NotImplementedException();
        }

    }
}
