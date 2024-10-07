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
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }


        public int ColourId { get; set; }
        [Required]
        public byte[] Image { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


    }
}
