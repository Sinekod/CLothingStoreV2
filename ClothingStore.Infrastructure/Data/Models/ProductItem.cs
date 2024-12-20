﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Models
{
    public class ProductItem
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(ProductImageId))]
        public ProductImage ProductImage { get; set; } = null!;

        public int ProductImageId { get; set; }
        public int SizeId { get; set; }   
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; } = null!;
        
        [Required]
        public int Quantity { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
