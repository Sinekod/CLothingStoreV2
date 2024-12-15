using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using ClothingStoreAgain.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Printing;

namespace ClothingStoreAgain.Controllers
{
    public class OrderController : Controller
    {
        private readonly ClothingStoreDbContext context;
        private readonly IOrderService orders;
        private readonly UserManager<IdentityUser> userManager;

        public OrderController(ClothingStoreDbContext context,IOrderService orders, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.orders = orders;
            this.userManager = userManager; 
        } 
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody]List<CartProductViewModel> model)
        {
            if (model==null||model.Count == 0)
            {
                return BadRequest("Something went wrong");
            }

            var user =await userManager.FindByNameAsync(User.Identity.Name);
         
        
            var OrderItems = new List<OrderItems>();
            Order order = new Order
            { 
               User = user,
               OrderedDate = DateTime.Now,

            };
            await context.Orders.AddAsync(order);  
            await context.SaveChangesAsync();  

            var productItemsOrders = await orders.PlaceOrder(model);
            
            foreach (var item in productItemsOrders)
            {
               item.Order = order;

            }
           
           await context.AddRangeAsync(productItemsOrders);
           await context.SaveChangesAsync();


            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            return View("OrderDetails");
        }
    
        [HttpPost]
        public async Task<IActionResult> OrderDetails([FromForm]OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var order = await context.Orders.FirstOrDefaultAsync(o=>o.UserId==user.Id);
          
            if (order is null)
            {
                return BadRequest("Something went wrong");
            }
         
            order.PhoneNumber = model.PhoneNumber;
            order.ShippimgAdress = model.ShippingAddress;
            order.PaymentMethod = model.PaymentMethod;
            order.City = model.City;
           
            await context.SaveChangesAsync();
            
            return View("DoneOrder");
   
        }
        [HttpGet]
        public async Task<IActionResult> DoneOrder()
        {
            return View("DoneOrder");
        }


    }
}
