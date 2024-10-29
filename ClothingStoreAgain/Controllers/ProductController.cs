using ClothingStore.Core.Constants;
using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStoreAgain.Extentions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ClothingStore.Core.Constants.Constants.PageConstants;
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

        public async Task<IActionResult> ShowAllProductsById(int id, int page)
        {
            if (id != 0)
            {

                HttpContext.Session.SetInt32("genderId", id);

            }

            var gottenProducts = await products.GetAllProductGenders(HttpContext.Session.GetInt32("genderId"));

            int count = gottenProducts.Count();
            if (page == 0)
            {
                page = 1;
            }
            int pageSize = Constants.PageConstants.pageSize;

            foreach (var product in gottenProducts)
            {
                string base64String = Convert.ToBase64String(product.Image);
                product.ImageString = $"data:image/jpeg;base64,{base64String}";

            }

            gottenProducts = gottenProducts.OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToList();

            var pegination = new PeginationModel(gottenProducts.ToList(), count, page, pageSize);
            string jsonString = JsonConvert.SerializeObject(pegination);
            HttpContext.Session.SetString("pages", jsonString);
            ViewData["pages"] = pegination;
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

        public async Task<IActionResult> ApplyDetails([FromForm] FilterCriteria filterCriteria, int page)
        {
            int? Idgender = HttpContext.Session.GetInt32("genderId");

            List<ProductImageViewModel> filteredProducts = new List<ProductImageViewModel>();

            if (page == 0)
            {
                filteredProducts = await products.FilteredProducts(Idgender, filterCriteria);
                foreach (var product in filteredProducts)
                {
                    string base64String = Convert.ToBase64String(product.Image);
                    product.ImageString = $"data:image/jpeg;base64,{base64String}";

                }

                page = 1;
                int count = filteredProducts.Count;
                filteredProducts = filteredProducts.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                var editedPegination = new PeginationModel(filteredProducts, count, page, Constants.PageConstants.pageSize);
                editedPegination.IsFiltered = true;
                HttpContext.Session.Set<FilterCriteria>("filtration", filterCriteria);
                ViewData["pages"] = editedPegination;

            }
            else
            {
                var filter = HttpContext.Session.Get<FilterCriteria>("filtration");
                filteredProducts = await products.FilteredProducts(Idgender, filter);

                foreach (var product in filteredProducts)
                {
                    string base64String = Convert.ToBase64String(product.Image);
                    product.ImageString = $"data:image/jpeg;base64,{base64String}";

                }
                int count = filteredProducts.Count;
                filteredProducts = filteredProducts.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var editedPegination = new PeginationModel(filteredProducts, count, page, Constants.PageConstants.pageSize);
                ViewData["pages"] = editedPegination;
                editedPegination.IsFiltered = true;


            }

            return View(nameof(ShowAllProductsById), filteredProducts);

        }

    }
}
