using System.ComponentModel.DataAnnotations;


namespace ClothingStore.Infrastructure.Data.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
