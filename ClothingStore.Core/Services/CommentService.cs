using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using ClothingStoreAgain.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services
{

    public class CommentService : ICommentService
    {
        private readonly ClothingStoreDbContext context;
        private readonly IServiceProducts products;
        private readonly UserManager<IdentityUser> userManager;
        public CommentService(ClothingStoreDbContext context, IServiceProducts products, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.products = products;
            this.userManager = userManager;

        }

        public async Task<Comment> AddComment(CommentViewModel comment, int productId)
        {
            var commentDatabase = new Comment()
            {
                CommentText = comment.Text,
                ProductItemId = productId,
                Rating = comment.Rating,
                Likes = comment.Likes,
                DateTime = DateTime.Now,
            };

            return commentDatabase;

        }

        public async Task<bool> CheckCommentExist(int commentId) => await context.Comments.AnyAsync(c => c.Id == commentId);

        public async Task<bool> CheckIfUserIsOwner(string userName,int commentId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            var comment = await context.Comments.FirstOrDefaultAsync(c=>c.Id==commentId&&c.UserId==user.Id);
            if (comment is null)
            {
                return false;
            }
            return true;

        }

        public async Task DeleteComment(int commentId, string username)
        {
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId && c.User.UserName == username);

            context.Comments.Remove(comment);
            context.SaveChanges();

        }

        public async Task<IEnumerable<CommentViewModel>> ShowComentsForProduct(int productId)
        {
            var product = await products.GetProductItem(productId);

            var comments = await context.Comments.Where(p => p.ProductItemId == product.Id)
                .Select(p => new CommentViewModel()
                {
                    Id = p.Id,
                    UserName = p.User.UserName,
                    Text = p.CommentText,
                    DateTime = p.DateTime.ToString("d"),
                    ProductId = productId,
                    Likes = p.Likes,
                    Rating = p.Rating

                }).ToListAsync();

            return comments;


        }



    }
}
