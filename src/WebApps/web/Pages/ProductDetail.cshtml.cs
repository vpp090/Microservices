using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ProductDetailModel : PageModel
    {


        public ProductDetailModel()
        {
           
        }

   
        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
          

        
        
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
         

            
            return RedirectToPage("Cart");
        }
    }
}