using CraftsStore.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsStore.Web.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
