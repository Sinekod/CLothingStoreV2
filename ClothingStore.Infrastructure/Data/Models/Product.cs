using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks.Dataflow;
using static ClothingStore.Infrastructure.Constants.Constants.ProductConstants;

namespace ClothingStore.Infrastructure.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxProductName)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string Description { get; set; } = string.Empty;
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }

        public bool IsShoe { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        public int BrandId { get; set; }
        [Required]
        public int Rating { get; set; }





    }
}
