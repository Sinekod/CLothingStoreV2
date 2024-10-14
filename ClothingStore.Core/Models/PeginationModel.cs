using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models
{
    public class PeginationModel
    {
        private List<ProductImageViewModel> products;
        private int count;
        private int page;
        private int pageSize;

        public List<ProductImageViewModel> Items { get; set; } = new List<ProductImageViewModel>();  
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public bool IsFiltered { get; set; } = false;

        public PeginationModel(List<ProductImageViewModel> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
      

        }

       

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;


    }
}
