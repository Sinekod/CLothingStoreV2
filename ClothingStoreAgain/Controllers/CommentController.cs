using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace ClothingStoreAgain.Controllers
{
    [Authorize(Roles = "User,Admin")]

    public class CommentController : Controller
    {
        private readonly ICommentService comments;
        private readonly IServiceProducts products;
        private readonly ClothingStoreDbContext context;
        private readonly UserManager<IdentityUser> userManager;



        public CommentController(ICommentService coments, IServiceProducts products, ClothingStoreDbContext context, UserManager<IdentityUser> userManager)
        {
            comments = coments;
            this.products = products;
            this.context = context;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel comment, int productId)
        {
            var username = User.Identity.Name;
            productId = HttpContext.Session.GetInt32("productId").Value;
            var currentUserId = await userManager.FindByNameAsync(username);
            if (!await products.CheckProductItem(productId))
            {
                return BadRequest();
            }
            if (comment == null)
            {
                return BadRequest();

            }
            if (productId == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                var commentService = await comments.AddComment(comment, productId);
                commentService.UserId = currentUserId.Id;

                context.Add(commentService);

            }
            await context.SaveChangesAsync();
            return Redirect($"https://localhost:7241/Product/ShowDescription/{productId}");

        }
        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {
            HttpContext.Session.SetInt32("productId", id);
            return View("AddComment");

        }

        public async Task<IActionResult> DeleteComment(int commentId)
        {
            if (commentId <= 0)
            {

                return NotFound("Comment not found");

            }
            if (!await comments.CheckCommentExist(commentId))
            {
                return NotFound("Comment not found");
            }
            string username = User.Identity.Name;
            var currentUserId = await userManager.FindByNameAsync(username);
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment.UserId != currentUserId.Id)
            {
                return Unauthorized();

            }


            await comments.DeleteComment(commentId, currentUserId.UserName);
            return View("ReviewDeleted");

        }
        [HttpGet]
        public async Task<IActionResult> EditComment(int commentId)
        {
            if (!await comments.CheckCommentExist(commentId))
            {
                return NotFound();
            }

            string username = User.Identity.Name;
            var currentUserId = await userManager.FindByNameAsync(username);
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            if (comment.UserId != currentUserId.Id)
            {
                return Unauthorized();
            }

            var commentEdited = new CommentViewModel()
            {
                Id = commentId,
                Text = comment.CommentText,
                ProductId = comment.ProductItemId,
                DateTime = comment.DateTime.ToString(),
                Rating = comment.Rating,
                Likes = comment.Likes,
                UserName = username

            };
            HttpContext.Session.SetInt32("commentIdEdit", commentId);
            return View("EditReview", commentEdited);

        }
        [HttpPost]
        public async Task<IActionResult> EditComment([FromForm] CommentViewModel model)
        {
            int commentId = HttpContext.Session.GetInt32("commentIdEdit").Value;
            var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            var userId = await userManager.FindByNameAsync(User.Identity.Name);
            await comments.DeleteComment(commentId,userId.UserName);

            comment = new Comment()
            {
                
                CommentText = model.Text,
                Rating = model.Rating,
                ProductItemId = comment.ProductItemId,
                Likes = comment.Likes,
                DateTime = comment.DateTime,
                UserId = userId.Id,

            };
             
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return Redirect($"https://localhost:7241/Product/ShowDescription/{comment.ProductItemId}");
        }





    }
}
