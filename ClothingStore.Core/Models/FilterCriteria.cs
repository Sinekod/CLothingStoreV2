using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models
{
    public class FilterCriteria
    {
        public int? Category { get; set; }
        public int? Brand { get; set; }
        public int? Size { get; set; }
        public  int? Color { get; set; }

        public int? ShoeSize { get; set; }
          
        public bool RealFiltration { get; set;  } = false;
    
        public List<CategoryViewModel> AvailableCategories { get; set; } = new List<CategoryViewModel>();
        public List<BrandViewModel> AvailableBrands { get; set; } = new List<BrandViewModel>();
        public IEnumerable<SizeViewModel> AvailableSizesForClothes { get; set; } = new List<SizeViewModel>();
        public IEnumerable<SizeViewModel> AvailableSizesForShoes { get; set; } = new List<SizeViewModel>();
        public List<ColourViewModel> AvailableColors { get; set; } = new List<ColourViewModel>();


    }
}
