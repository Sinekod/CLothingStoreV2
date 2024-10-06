using System.ComponentModel.DataAnnotations;
using static ClothingStore.Infrastructure.Constants.Constants.BrandConstants;
namespace ClothingStore.Infrastructure.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxBrandName)]
        public string Name { get; set; } = string.Empty;
    }
}