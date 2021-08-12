using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftsStore.Web.Pages
{
    public class NewProductModel : PageModel
    {
        private readonly IDbProductService _productService;
        public NewProductModel( IDbProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
           
          }

        public async Task <IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var products = await _productService.GetProductAsync(Product.Id);
                if(products.Any(c => c.Id == Product.Id))
                 {   ModelState.AddModelError(string.Empty,"El Id ya esta siendo usado");
                        return Page();
                    }

                await _productService.AddProductAsync(Product);
                return RedirectToPage("/index");
            }
              else
            {
                ModelState.AddModelError(string.Empty,"Hay datos invalidos en tu informacion");
                return Page();
            }
        }


    }
}
