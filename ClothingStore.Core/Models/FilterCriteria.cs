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
        public CategoryViewModel? Category { get; set; }
        public BrandViewModel? Brand { get; set; }
        public string? Size { get; set; }
        public  ColourViewModel? Color { get; set; }

        public List<CategoryViewModel> AvailableCategories { get; set; } =  new List<CategoryViewModel>();
        public List<BrandViewModel> AvailableBrands { get; set; } = new List<BrandViewModel>();
        public List<string> AvailableSizesForClothes { get; set; } = new List<string>();
        public List<int> AvailableSizesForShoes { get; set; } = new List<int>();
        public List<ColourViewModel> AvailableColors { get; set; } = new List<ColourViewModel>();


    }
}
