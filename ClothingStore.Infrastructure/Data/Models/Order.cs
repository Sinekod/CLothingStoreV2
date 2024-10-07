using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Models
{

    public class Order
    {
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;

        public int ProductItemId { get; set; }
        [ForeignKey(nameof(ProductItemId))]
        public ProductItem ProductItem { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DateWhenOrdered { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tottal { get; set; }

        public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    }
}
