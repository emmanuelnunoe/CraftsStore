using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CraftsStore.Web.Models;
using CraftsStore.Web.Services;
using CraftsStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CraftsStore.Web.Services.Implementations
{
    public class JsonFileProductService : IProductService
    {
        public readonly IWebHostEnvironment _WebHostEnvironment;

        public JsonFileProductService(IWebHostEnvironment webHostEnvironment) // injeccion de dependencias viene de principios solids
        {
            _WebHostEnvironment = webHostEnvironment;
        }


        private string JsonFileName
        {
            // obtiene la ruta local del archivo Json.
            get { return Path.Combine(_WebHostEnvironment.WebRootPath, "data", "products.json"); } // el _WebHostEnvironment Arregla las diagonales para que no nos equivoquemos
            

        }


        public async Task<IEnumerable <Product>> GetProductsAsync()
        {
            // leer nuestro archivo de json
            using var jsonFileReader = File.OpenText(JsonFileName); // using: se utiliza para abrir una conexion, leer el archivo y cerrar la conexion.
            // regresarlo en objeto de .net
            return await JsonSerializer.DeserializeAsync<List<Product>>(jsonFileReader.BaseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
                

           
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var products = await GetProductsAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }
     
        
        public async Task<IEnumerable<Product>> GetMakerProductsAsync(string name)=>(await GetProductsAsync()).Where(c => c.Maker == name);
        

    }

}
