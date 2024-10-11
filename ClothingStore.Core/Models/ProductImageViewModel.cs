using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public byte[] Image { get; set; }

        public string ImageString { get; set; } = string.Empty;

        public int GenderId { get; set; }


    }
}
