using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface IServiceProducts
    {
        public Task<IEnumerable<ProductImageViewModel>> GetAllProductsAsync();

        public Task<ProductItemViewModel> ShowDetails(int id);

        public Task<bool> CheckProductExist(int id);

        public Task<IEnumerable<ColourViewModel>> GetAllColoursForProduct(int id);


        public Task<IEnumerable<SizeViewModel>> GetAllSizesForProduct(int id);

        public Task<IEnumerable<ProductImageViewModel>> GetAllProductGenders(int? genderId);


        public Task<FilterCriteria> GetAllAvailableCriteriaForProducts(int genderId);

        public Task<List<ProductImageViewModel>> FilteredProducts(int? genderId,FilterCriteria? filter);

        public Task<bool> CheckIfProductNameExists(string name);
        public Task<bool> CheckIfProductSizeExists(string name);

        public Task<Size> GetSizeByName(string name);

        public Task<bool> CheckCategoryExists(string category,int genderId);

        public Task<IEnumerable<GenderViewModel>> GetAllGenders();

        public Task<IEnumerable<ColourViewModel>> GetAllColours();

        public Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        public Task<IEnumerable<BrandViewModel>> GetAllBrands();

        public Task<bool> CheckColourExist(int id);

        public Task<bool> CheckBrandExist(int id);

        public Task<ProductItem> GetProductItem(int id);

        public Task<bool> CheckProductItem(int id);

        public Task<Size> GetSizeById(int id);

        public Task<Colour> GetColourById(int id);


    }
}
