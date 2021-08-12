using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using CraftsStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CraftsStore.Web.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Task<Product> Product{ get; set; }
        private readonly IDbProductService _productService;

        public DetailsModel(IDbProductService jsonFileProductService)
        {
            _productService = jsonFileProductService;
        }



        public void OnGet()
        {
            // Utilizar el id para obtener el producto del servicio de jsonfileProductService
            // y mostrar todas sus propiedades en la pagina en la pagina hmtl de razor

            Product = _productService.GetProductAsync(Id);
            

        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _productService.DeleteProductAsync(Id);
            return RedirectToPage("/Index");
        }

    }
}
