using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class ProductService : IServiceProducts
    {
        private readonly ClothingStoreDbContext context;

        public ProductService(ClothingStoreDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> CheckProductExist(int id) =>
            await context.ProductImages.AnyAsync(x => x.Id == id);


        public async Task<IEnumerable<ColourViewModel>> GetAllColoursForProduct(int id)
        {
            return await context.ProductImages.Where(p => p.Id == id)
             .Select(p => new ColourViewModel
             {
                 Id = p.ColourId,
                 Name = p.Colour.Name


             }).ToListAsync();
        }

        public async Task<List<ProductImageViewModel>> GetAllProductGenders(int genderId)
        {
            var products = await GetAllProductsAsync();

            return products.Where(p => p.GenderId != genderId).ToList();


        }

        public async Task<List<ProductImageViewModel>> GetAllProductsAsync()
        {
            return await context.ProductImages.Select(p => new ProductImageViewModel
            {
                Id = p.Id,
                Name = p.Product.Name,
                Category = p.Product.Category.CategoryName,
                Price = p.Price,
                Image = p.Image,
                GenderId = p.Product.Category.GenderId

            }).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllSizesForProduct(int id) =>
            await context.ProductItems.AsNoTracking().Where(p => p.Id == id).Select(p => p.Size).ToListAsync();

        public async Task<ProductItemViewModel> ShowDetails(int id)
        {
            IEnumerable<ColourViewModel> colours = await GetAllColoursForProduct(id);
            IEnumerable<string> sizes = await GetAllSizesForProduct(id);

            var product = await context.ProductItems.Where(p => p.Id == id).Select(p => new ProductItemViewModel
            {
                Id = p.Id,
                Price = p.ProductImage.Price,
                Name = p.ProductImage.Product.Name,
                Description = p.ProductImage.Product.Description,
                Colours = colours,
                Sizes = sizes,
                Image = p.ProductImage.Image,
                Brand = p.ProductImage.Product.Brand.Name,
                Category = p.ProductImage.Product.Category.CategoryName


            }).AsNoTracking().FirstOrDefaultAsync();

            return product;

        }






    }
}
