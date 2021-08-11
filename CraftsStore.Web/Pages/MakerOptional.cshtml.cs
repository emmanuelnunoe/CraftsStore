using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using CraftsStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftsStore.Web.Pages
{
    public class MakerOptionalModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Maker { get; set; }
        private readonly IProductService _productService;
        public List<Product> MakerProducts { get; private set; }


        public MakerOptionalModel(IProductService jsonFileProductService)
        {
            _productService = jsonFileProductService;
        }


        public void OnGet()
        {

            // otra manera de enlazar parametro de url con la propiedad
            Maker = Request.Query["maker"];
        }
    }
}
