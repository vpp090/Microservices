using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
     

        public IndexModel()
        {
           
        }

        public async Task<IActionResult> OnGetAsync()
        {
           
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
           
            return RedirectToPage("Cart");
        }
    }
}
