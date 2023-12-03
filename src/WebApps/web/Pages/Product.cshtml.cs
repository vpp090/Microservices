using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ProductModel : PageModel
    {
     

        public ProductModel()
        {
         
        }

     

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            return Page();
        }
    }
}