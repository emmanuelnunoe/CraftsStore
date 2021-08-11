using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CraftsStore.Web.Pages
{
    public class MakerProductsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        private readonly JsonFileProductService _productService;
        public List<Product> MakerProducts { get; private set; }


        public MakerProductsModel(JsonFileProductService jsonFileProductService)
        {
            _productService = jsonFileProductService;
        }

        public void OnGet()
        {
            // otra manera de enlazar parametro de url con la propiedad
            // Maker = Request.Query["maker"];
           MakerProducts = _productService.MakerProducts(Id);
        }
    }
}
