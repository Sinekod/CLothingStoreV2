using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ColourId))]
        public Colour Colour { get; set; } = null!;

        public int ColourId { get; set; }
        [Required]
        public byte[] Image { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        
        public decimal SalePrice { get; set; }



    }
}
