using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Constants
{
    public static class Constants
    {
        public static class PageConstants
        {
            public const int pageSize = 1;
        
        }
        public static class ProductForumConstants 
        {
            public const int MaxProductNameLenght = 30;
            public const int MinProductNameLenght = 3;
            public const int MinDescriptionLenght = 10;
            public const int MaxDescriptionLenght = 1500;
            public const int MaxPrice = 2000;
            public const int MinPrice = 3;
            public const int MaxQuantity = 999;
            public const int MinQuantity = 3;
            public const int MaxSizeLeght = 5;
            public const int MinSizeLeght = 1;



        }


    }
}
