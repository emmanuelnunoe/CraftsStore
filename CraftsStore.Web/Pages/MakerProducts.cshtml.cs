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
    public class MakerProductsModel : PageModel
    {
       
      
        private readonly IProductService _productService;
    
        public MakerProductsModel(IProductService jsonFileProductService)
        {
            _productService = jsonFileProductService;
        }

         [BindProperty(SupportsGet = true)]
         public string Name { get; set; }
   
        public IEnumerable<Product> MakerProducts { get; private set; }
        public async Task OnGetAsync()
        {
            // otra manera de enlazar parametro de url con la propiedad
            // Maker = Request.Query["maker"];
           MakerProducts = await _productService.GetMakerProductsAsync(Name);
        }
    }
}
