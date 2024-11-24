using ClothingStore.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IServiceProducts products;

        public CartService(IServiceProducts products)
        {
            this.products = products;
        }

        public Task AddProductToCart(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
