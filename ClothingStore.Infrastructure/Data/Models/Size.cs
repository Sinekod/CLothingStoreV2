﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.Models
{
    public class Size
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; } = string.Empty;
    }
}
