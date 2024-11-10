using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ClothingStore.Infrastructure.Constants.Constants.ComentConstants;
namespace ClothingStore.Infrastructure.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxComentLenght)]
        public string CommentText { get; set; } = string.Empty;

        public int ProductItemId { get; set; }
        [ForeignKey(nameof(ProductItemId))]
        
        public ProductItem ProductItem { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
       
        public string UserId { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }
    }


}
