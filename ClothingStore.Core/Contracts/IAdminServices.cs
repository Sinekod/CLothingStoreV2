
using ClothingStore.Core.Models;
using System.IO;
using System.Threading.Tasks;
namespace ClothingStore.Core.Contracts
{
    public interface IAdminServices
    {
        public Task AddProductToDatabase(ProductAddForm product);

        public Task DeleteProduct(int productId);

        public Task AddColour(string colourName);


        public Task AddBrand(string brandName);

    }
}
