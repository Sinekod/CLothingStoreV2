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

        [Required]
        public DateTime OrderedDate { get; set; }
      
      
        public string ShippimgAdress { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string City{ get; set; } =string.Empty;


        public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    }
}
