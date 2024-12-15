using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using static ClothingStore.Core.Constants.MessageConstants;

namespace ClothingStore.Core.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        public string PaymentMethod { get; set; } = string.Empty;



    }
}
