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

        //public Task<PeginationModel<ProductImageViewModel>> Pegination(int genderId, int page, int pageSize);


    }
}
