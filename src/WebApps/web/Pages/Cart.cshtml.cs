using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        

        public CartModel()
        {
           
        }

       

        public async Task<IActionResult> OnGetAsync()
        {
            

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            
            return RedirectToPage();
        }
    }
}