using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Configuration.Internal;
using System.Diagnostics;

namespace ClothingStoreAgain.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IServiceProducts products;
        private readonly IAdminServices adminService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
      
        public AdminController(IServiceProducts _products, IAdminServices _adminServices,
            UserManager<IdentityUser> _userManager,RoleManager<IdentityRole> _roleManager)
        {
            products = _products;
            adminService = _adminServices;
            roleManager = _roleManager;
            userManager = _userManager;
        }


        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {

            var product = new ProductAddForm()
            {
                Genders = await products.GetAllGenders(),
                Brands = await products.GetAllBrands(),
                Colours = await products.GetAllColours(),
                Categories = await products.GetAllCategories(),

            };
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddForm product, IFormFile image)
        {
            string[] availableExtentions = { ".jpg", ".jpeg", ".png" };
            ModelState.Remove("Image");

            if (await products.CheckIfProductNameExists(product.Name))
            {
                ModelState.AddModelError(nameof(product.Name), "Product with this name already exists");
            }
            if (!await products.CheckColourExist(product.ColourId))
            {
                ModelState.AddModelError(nameof(product.ColourId), "Colour does not exist");
            }
            if (!await products.CheckBrandExist(product.BrandId))
            {
                ModelState.AddModelError(nameof(product.BrandId), "Brand does not exist");
            }

            if (image is null)
            {
                ModelState.AddModelError(nameof(image), "Image is required");
            }
            if (!ModelState.IsValid)
            {
                product.Colours = await products.GetAllColours();
                product.Brands = await products.GetAllBrands();
                product.Genders = await products.GetAllGenders();
                product.Categories = await products.GetAllCategories();
                return View(product);
            }
            if (ModelState.IsValid)
            {
                var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
                if (!Array.Exists(availableExtentions, e => e.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError(nameof(image), "The image type must be .jpg,.jpeg,.png");
                }
                product.Image = ConvertImagesToBytes(image).Result;
                await adminService.AddProductToDatabase(product);
            }
            return View();
        }

        private async Task<byte[]> ConvertImagesToBytes(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }


        }
        
        public async Task<IActionResult> PromotePeople(string username,string role)
        {
            var user = await userManager.FindByNameAsync(username);
              
            if (user==null)
            {
                return BadRequest("User not found");
            }
            var roleExist = await roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                return BadRequest("Role does not exist");

            }
            var isInRole = await userManager.IsInRoleAsync(user,role);
            if (isInRole)
            {
                return BadRequest("User is in Role");
            }
            await userManager.AddToRoleAsync(user,role);

            return Ok(200);

        }








    }
}
