using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{
    public class OrderServices : IOrderService
    {
        private readonly ClothingStoreDbContext context;
        private readonly IServiceProducts productsService;

        public OrderServices(ClothingStoreDbContext context, IServiceProducts products)
        {
            this.context = context;
            this.productsService = products;
        }

        public async Task<List<OrderItems>> PlaceOrder(List<CartProductViewModel> model)
        {
            List<OrderItems> ordeItems = new List<OrderItems>();
            foreach (var item in model)
            {
                var productOrderItems = await context.ProductItems.Where(p => p.Id == item.Id
                && p.ProductImage.Colour.Name == item.Colour && p.Size.Name == item.Size
                && p.ProductImage.Product.Name==item.Name)
                .Select(p => new OrderItems
                {
                    ProductItemId = p.Id,
                    Price = p.ProductImage.Price,
                    Quantity = item.Quantity,
                    Total = item.Quantity * p.ProductImage.Price


                }).FirstOrDefaultAsync();

                if (productOrderItems is not null)
                {
                    ordeItems.Add(productOrderItems);
                }

            }
            return ordeItems;


        }



    }
}
