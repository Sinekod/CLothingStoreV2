
using ClothingStore.Core.Models;
using System.IO;
using System.Threading.Tasks;
namespace ClothingStore.Core.Contracts
{
    public interface IAdminServices
    {
        public Task AddProductToDatabase(ProductAddForm product);


    }
}
