namespace ClothingStore.Infrastructure.Data.Models;

using System.ComponentModel.DataAnnotations;
using static ClothingStore.Infrastructure.Constants.Constants.ColourConstants;

public class Colour
{
    public int Id { get; set; }
    [Required]
    [MaxLength(MaxColourName)]
    public string Name { get; set; } = string.Empty;  


}