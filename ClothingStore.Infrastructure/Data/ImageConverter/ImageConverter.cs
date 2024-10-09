using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.ImageConverter
{
    [NotMapped]
    public static class ImageConverter
    {
        public static byte[] ImageToByteArray(string imgPath)
        { 
          return File.ReadAllBytes(imgPath);
        }







    }
}
