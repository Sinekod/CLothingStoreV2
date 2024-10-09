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


    }


}
