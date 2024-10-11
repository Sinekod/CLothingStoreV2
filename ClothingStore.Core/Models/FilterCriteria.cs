using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models
{
    public class FilterCriteria
    {
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }

        public List<string> AvailableCategories { get; set; } = new List<string>();
        public List<string> AvailableBrands { get; set; } = new List<string>();
        public List<string> AvailableSizes { get; set; } = new List<string>();
        public List<string> AvailableColors { get; set; } = new List<string>();


    }
}
