using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class AdminService : IAdminServices
    {
        private readonly IServiceProducts products;
        private readonly ClothingStoreDbContext context;
        public AdminService(IServiceProducts _products, ClothingStoreDbContext _context)
        {
            products = _products;
            context = _context;
        }

        public async Task AddProductToDatabase(ProductAddForm product)
        {
            Category category = new Category();

            if (!products.CheckCategoryExists(product.CategoryName, product.GenderId).Result)
            {
                category = new Category()
                {
                    GenderId = product.GenderId,
                    CategoryName = product.CategoryName,

                };
                context.Add(category);
            }
            else
            {
                category = await context.Categories.FirstOrDefaultAsync(c => c.GenderId == product.GenderId && c.CategoryName == product.CategoryName);
            }
            var productOr = new Product()
            {

                Name = product.Name,
                Description = product.Description,
                Category = category,
                BrandId = product.BrandId,


            };
            
            var productImage = new ProductImage()
            {
                Product = productOr,
                Image = product.Image,
                ColourId = product.ColourId,

                Price = product.Price,
            };
            var size = new Size();

            if (!await products.CheckIfProductSizeExists(product.Size))
            {
                size = new Size()
                {
                    Name = product.Size,
                };
                context.AddAsync(size);

            }
            else
            {
                size = products.GetSizeByName(product.Size).Result;

            }

            var productItem = new ProductItem()
            {
                ProductImage = productImage,
                Size = size,
                Quantity = product.Quantity,

            };

            context.Add(productOr);
            context.Add(productImage);
            context.Add(productItem);
           await context.SaveChangesAsync();



        }
    }
}
