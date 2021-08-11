using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using CraftsStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
        public IEnumerable<Product> Products { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, IProductService jsonFileProductService)
        {
            _logger = logger;
            _productService = jsonFileProductService;
        }

      

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}
