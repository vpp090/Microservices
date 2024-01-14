
using EcomWebApp.Contracts;
using EcomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomWebApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;
      
        public CartModel(IBasketService basketService, ICatalogService catalogService)
        {
            _basketService = basketService;
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "vv";
            Cart = await _basketService.GetBasket(userName);

            if(Cart is null)
            {
                throw new ArgumentException("No cart on this username");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "vv";
            var basket = await _basketService.GetBasket(userName);

            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            basket.Items.Remove(item);

            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}