using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface ICartService
    {

        public Task AddProductToCart(int productId);
    }
}
