using EcomWebApp.Contracts;
using EcomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomWebApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;
        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();
     
        public async Task<IActionResult> OnGetAsync()
        {
            string userName = "vv";

            Orders = await _orderService.GetOrdersByUserName(userName);
       
            return Page();
        }       
    }
}