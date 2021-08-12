
using CraftsStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        public Task <IEnumerable<Product>>GetMakerProductsAsync(string maker);

        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task <Product> GetProductAsync(string Id);

       
    }
}
