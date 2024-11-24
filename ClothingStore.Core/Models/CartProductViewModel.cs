using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models
{
    public class CartProductViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public string Colour { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string Brand { get; set; } = string.Empty;

        public decimal Price { get; set; }

    }
}
