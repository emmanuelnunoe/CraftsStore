
using CraftsStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> MakerProducts(string maker);

        public Product[] GetProducts();
         public Product GetProduct(string Id);
    }
}
