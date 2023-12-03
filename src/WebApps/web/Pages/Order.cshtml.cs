using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class OrderModel : PageModel
    {
     
        public OrderModel()
        {
        
        }

     
        public async Task<IActionResult> OnGetAsync()
        {
       
            return Page();
        }       
    }
}