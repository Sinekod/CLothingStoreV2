using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace ClothingStoreAgain.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceProducts products;
        private readonly ClothingStoreDbContext context;
        public ProductController(IServiceProducts _products, ClothingStoreDbContext _context)
        {
            products = _products;
            context = _context;
        }
        [HttpGet]
        
        public async Task<IActionResult> ShowAllProductsById(int id)
        { 
            var gottenProducts = await products.GetAllProductGenders(id);
            foreach ( var product in gottenProducts)
            {
                string base64String = Convert.ToBase64String(product.Image);
                product.ImageString = $"data:image/jpeg;base64,{base64String}";
                
            }
           
            return View(gottenProducts);

        
        }
        [HttpGet]
        public async Task<IActionResult> ShowDescription(int id)
        {
            if (!await products.CheckProductExist(id))
            {
               return BadRequest();
            }
             var productDescription = await products.ShowDetails(id);
            string base64String = Convert.ToBase64String(productDescription.Image);
            productDescription.ImgIrl = $"data:image/jpeg;base64,{base64String}";

            return View(productDescription);

        }
        public async Task<IActionResult> ApplyDetails([FromQuery] int id, [FromForm] FilterCriteria filterCriteria)
        {
            return null;
            

        }




    }
}
