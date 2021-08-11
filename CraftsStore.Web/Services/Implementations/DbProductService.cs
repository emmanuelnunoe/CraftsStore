using CraftsStore.Web.Data;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Web.Services.Implementations
{
    interface DbProductService : IProductService
    {
        private readonly ApplicationContext _context;
        public DbProductService(ApplicationContext dbContext) => _context = dbContext;

        public IEnumerable<Product> 
        public List<Product> MakerProducts(string maker)

    }
}
