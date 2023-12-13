﻿using EcomWebApp.Contracts;
using EcomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomWebApp.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public CatalogModel Product { get; set; }

        public ProductDetailModel(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
        }
       
        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
          
            if(productId == null)
                return NotFound();

            Product = await _catalogService.GetCatalog(productId);
            if (Product == null)
                return NotFound();
        
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogService.GetCatalog(productId);

            var userName = "vv";
            var basket = await _basketService.GetBasket(userName);
            Color colorEn = (Color)Enum.Parse(typeof(Color), Color);

            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = Quantity,
                Color = (int)colorEn
            }) ;

            return RedirectToPage("Cart");
        }
    }
}