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

        public int ProductImageId { get; set; }
        [ForeignKey(nameof(ProductImageId))]
        public ProductImage ProductImage { get; set; } = null!;


    }


}
