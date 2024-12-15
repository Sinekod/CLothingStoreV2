using ClothingStore.Core.Models;
using ClothingStore.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentViewModel>> ShowComentsForProduct(int productId);

        public Task<Comment> AddComment(CommentViewModel comment,int productId);

        public Task DeleteComment(int commentId,string userId);

    
        public Task<bool> CheckCommentExist(int commentId);

        public Task<bool> CheckIfUserIsOwner(string userName,int commentId);

    }
}
