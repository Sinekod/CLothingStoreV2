using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.SeededDb
{

    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            var data = new SeededDb();

            builder.HasData(new ProductImage[] { data.ProductImage1,data.ProductImage2,data.ProductImage3,data.ProductImage4 }); ;

        }
    }
}
