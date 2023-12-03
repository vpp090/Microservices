using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
   

        public CheckOutModel()
        {
            
        }

     

        public async Task<IActionResult> OnGetAsync()
        {
         
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
         
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}