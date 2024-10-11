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
        public Task<List<ProductImageViewModel>> GetAllProductsAsync();

        public Task<ProductItemViewModel> ShowDetails(int id);

        public Task<bool> CheckProductExist(int id);

        public Task<IEnumerable<ColourViewModel>> GetAllColoursForProduct(int id);


        public Task<IEnumerable<string>> GetAllSizesForProduct(int id);

        public Task<List<ProductImageViewModel>> GetAllProductGenders(int genderId);       





    }
}
