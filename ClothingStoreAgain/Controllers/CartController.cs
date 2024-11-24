using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using ClothingStoreAgain.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace ClothingStoreAgain.Controllers
{
    
    public class CartController : Controller
    {
        private readonly IServiceProducts products;
        private readonly ClothingStoreDbContext context;

        public CartController(IServiceProducts products, ClothingStoreDbContext context)
        {
            this.products = products;
            this.context = context;
        }

        public async Task<IActionResult> AddToCart(ProductItemViewModel model)
        {
            var cart = HttpContext.Session.GetList<CartProductViewModel>("Cart") ?? new List<CartProductViewModel>();
            if (model is null)
            {
                return NotFound();
            }
            if (!await products.CheckProductItem(model.Id))
            {
                return NotFound();
            }
            var existingItem = cart.FirstOrDefault(p => p.Id == model.Id);
            if (existingItem != null)
            {
                model.Quantity++;
            }
            else
            {
                var cartModel = new CartProductViewModel()
                {
                    Name = model.Name,
                    Price = decimal.Parse(model.Price.ToString()),
                    ImgUrl = model.ImgIrl,
                    Quantity = 1,
                    Id = model.Id,
                    Size = products.GetSizeById(model.SizeId).Result.Name,
                    Colour = products.GetColourById(model.ColourId).Result.Name,
                    
                };
                
                cart.Add(cartModel);
            }
            HttpContext.Session.SetList("Cart", cart);

            return Redirect($"/Product/ShowDescription/{model.Id}");

        }
        public async Task<IActionResult> ShowCart()
        {
            var products = HttpContext.Session.GetList<CartProductViewModel>("Cart");
            return View("CartVisualistion", products);

        }
        public async Task<IActionResult> Deleteproduct(int productId)
        {  
            var cart = HttpContext.Session.GetList<CartProductViewModel>("Cart");
            if (!cart.Any(p=>p.Id==productId))
            {
                return NotFound();
            }
            
            else
            {
                var product = cart.FirstOrDefault(p=>p.Id==productId);
                cart.Remove(product);
                
            }

            return View();

        }

       

        



    }
}
