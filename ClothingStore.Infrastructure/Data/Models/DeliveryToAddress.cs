using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Models
{
    public class DeliveryToAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set;} = string.Empty;
        [Required]
        public string PhoneNumber { get; set; }= string.Empty;
        [Required]
        public int Number { get; set; }
        [Required]
        public string StreetName { get; set; } = string.Empty;

        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();










    }
}
