using EcomWebApp.Contracts;
using EcomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomWebApp.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;
        
        public CheckOutModel(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "vv";
            Cart = await _basketService.GetBasket(userName);
         
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "vv";
            Cart = await _basketService.GetBasket(userName);
         
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = userName;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketService.CheckoutBasket(Order);
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}