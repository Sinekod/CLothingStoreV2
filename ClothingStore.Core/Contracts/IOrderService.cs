using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface IOrderService
    {
        public Task<List<OrderItems>> PlaceOrder(List<CartProductViewModel> model);


    }
}
