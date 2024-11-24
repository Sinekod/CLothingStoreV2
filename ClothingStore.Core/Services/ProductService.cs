using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
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

        public async Task<FilterCriteria> GetAllAvailableCriteriaForProducts(int genderId)
        {

            var availableCategories = await context.Categories.Where(p => p.GenderId == genderId)
            .Select(p => new CategoryViewModel()
            {
                Id = p.Id,
                Name = p.CategoryName


            }).Distinct().AsNoTracking().ToListAsync();

            var availableBrands = await context.Products.Where(p => p.Category.GenderId == genderId)
            .Select(p => new BrandViewModel()
            {
                Id = p.BrandId,
                Name = p.Brand.Name


            }).Distinct().AsNoTracking().ToListAsync();


            var availableColours = await context.ProductImages
                .Where(p => p.Product.Category.GenderId == genderId
                )
                .Select(p => new ColourViewModel()
                {
                    Id = p.ColourId,
                    Name = p.Colour.Name,


                }).ToListAsync();

            var sizes = await context.ProductItems
                .Where(p => p.ProductImage.Product.Category.GenderId == genderId)
                .Select(p => new SizeViewModel()
                {
                    Id = p.SizeId,
                    Name = p.Size.Name,


                }).ToListAsync();

            FilterCriteria filterCriteria = new FilterCriteria()
            {
                AvailableCategories = availableCategories,
                AvailableBrands = availableBrands,
                AvailableColors = availableColours,
                AvailableSizesForClothes = FilterClothingSizes(sizes),
                AvailableSizesForShoes = FilterShoeSizes(sizes)

            };

            return filterCriteria;

        }

        public async Task<IEnumerable<ColourViewModel>> GetAllColoursForProduct(int id)
        {
            return await context.ProductImages.Where(p => p.Id == id)
             .Select(p => new ColourViewModel
             {
                 Id = p.ColourId,
                 Name = p.Colour.Name


             }).ToListAsync();
        }

        public async Task<IEnumerable<ProductImageViewModel>> GetAllProductGenders(int? genderId)
        {
            var products = await GetAllProductsAsync();

            return products.Where(p => p.GenderId == genderId).ToList();


        }

        public async Task<IEnumerable<ProductImageViewModel>> GetAllProductsAsync()
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

        public async Task<IEnumerable<SizeViewModel>> GetAllSizesForProduct(int id)
        {
            return await context.ProductItems.Where(p => p.Id == id).Select(p => new SizeViewModel()
            {
                Id = p.SizeId,
                Name = p.Size.Name,

            }).ToListAsync();

        }


        public async Task<ProductItemViewModel> ShowDetails(int id)
        {
            IEnumerable<ColourViewModel> colours = await GetAllColoursForProduct(id);
            IEnumerable<SizeViewModel> sizes = await GetAllSizesForProduct(id);

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
        private IEnumerable<SizeViewModel> FilterShoeSizes(IEnumerable<SizeViewModel> sizes)
        {
            var shoeSizes = new List<SizeViewModel>();
            foreach (var size in sizes)
            {
                int a;
                if (int.TryParse(size.Name, out a))
                {
                    shoeSizes.Add(size);
                }

            }
            return shoeSizes;

        }
        private IEnumerable<SizeViewModel> FilterClothingSizes(IEnumerable<SizeViewModel> sizes)
        {
            var clothSizes = new List<SizeViewModel>();
            foreach (var size in sizes)
            {
                int a;
                if (!int.TryParse(size.Name, out a))
                {
                    clothSizes.Add(size);
                }

            }
            return clothSizes;

        }


        public async Task<List<ProductImageViewModel>> FilteredProducts(int? genderId, FilterCriteria? filter)
        {

            var products = context.ProductItems.Include(x => x.ProductImage)
                .Include(p => p.ProductImage.Product).Where(p => p.ProductImage.Product.Category.GenderId == genderId).ToList();



            if (!string.IsNullOrEmpty(filter.Color.ToString()))
            {
                products = products.Where(p => p.ProductImage.ColourId == filter.Color).ToList();

            }
            if (!string.IsNullOrEmpty(filter.Category.ToString()))
            {
                ;
                products = products.Where(p => p.ProductImage.Product.CategoryId == filter.Category).ToList();

            }
            if (!string.IsNullOrEmpty(filter.Brand.ToString()))
            {
                products = products.Where(p => p.ProductImage.Product.BrandId == filter.Brand).ToList();
            }
            if (!string.IsNullOrEmpty(filter.Size.ToString()))
            {
                products = products.Where(p => p.SizeId == filter.Size).ToList();
            }
            if (!string.IsNullOrEmpty(filter.ShoeSize.ToString()))
            {
                products = products.Where(p => p.SizeId == filter.Size).ToList();
            }

            var ids = new List<int>();
            products.ForEach(i => ids.Add(i.Id));
            var imageProducts = await context.ProductImages.Where(p => ids.Contains(p.Id)).Select(p => new ProductImageViewModel()
            {
                Id = p.Id,
                Name = p.Product.Name,
                Category = p.Product.Category.CategoryName,
                Price = p.Price,
                Image = p.Image,
                GenderId = p.Product.Category.GenderId,

            }).ToListAsync();

            return imageProducts;


        }

        public async Task<bool> CheckIfProductNameExists(string name) => await context.Products.AnyAsync(p => p.Name == name);

        public async Task<bool> CheckIfProductSizeExists(string name) => await context.Sizes.AnyAsync(p => p.Name == name);

        public async Task<Size> GetSizeByName(string name) => await context.Sizes.FirstOrDefaultAsync(p => p.Name == name);

        public async Task<bool> CheckCategoryExists(string category, int genderId) => await context.Categories.AnyAsync(c => c.CategoryName == category && c.GenderId == genderId);

        public async Task<IEnumerable<GenderViewModel>> GetAllGenders()
        {
            return await context.Genders.Select(g => new GenderViewModel()
            {
                GenderName = g.Name,
                Id = g.Id,
            }).ToListAsync();


        }

        public async Task<IEnumerable<ColourViewModel>> GetAllColours()
        {
            return await context.Colours.Select(c => new ColourViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return await context.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.CategoryName

            }).ToListAsync();
        }

        public async Task<IEnumerable<BrandViewModel>> GetAllBrands()
        {
            return await context.Brands.Select(b => new BrandViewModel()
            {
                Id = b.Id,
                Name = b.Name,

            }).ToListAsync();
        }

        public async Task<bool> CheckColourExist(int id)=>await context.Colours.AnyAsync(c => c.Id == id);

        public async Task<bool> CheckBrandExist(int id) => await context.Brands.AnyAsync(b=>b.Id==id);

        public async Task<ProductItem>? GetProductItem(int id) => await context.ProductItems.FirstOrDefaultAsync(p => p.Id == id);    
      

        public async Task<bool> CheckProductItem(int id) => await context.ProductImages.AnyAsync(p=>p.Id==id);

        public async Task<Size> GetSizeById(int id) => await context.Sizes.FirstOrDefaultAsync(p => p.Id == id);


        public async Task<Colour> GetColourById(int id) => await context.Colours.FirstOrDefaultAsync(p=>p.Id==id);
      
    }
}
