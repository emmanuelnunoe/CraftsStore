using CraftsStore.Web.Data;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services.Interfaces;
using CraftsStore.Web.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CraftsStore.Web.Services.Implementations
{
   class DbProductService : IDbProductService
    {
        private readonly ApplicationContext _context;
        public DbProductService(ApplicationContext dbContext) => _context = dbContext;

        public async Task AddProductAsync(Product product)
        {
            await _context.AddAsync(product);
            await  _context.SaveChangesAsync();
             
        }


        public async Task UpdateProductAsync(Product newProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == newProduct.Id);
            if (product is Product)
                return;
            else
            {
                _context.Update(product);
                await _context.SaveChangesAsync()
;
            }
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetMakerProductsAsync(string name) => await _context.Products.Where(c => c.Maker == name).ToListAsync();

        public async Task <Product>GetProductAsync(string Id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

    }
}
