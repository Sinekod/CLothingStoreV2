using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ClothingStore.Infrastructure.Constants.Constants.CategoryConstants;


namespace ClothingStore.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxCategoryName)]
        public string CategoryName { get; set; } = string.Empty;

        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; } = null!;

        public int GenderId { get; set; }





    }
}
