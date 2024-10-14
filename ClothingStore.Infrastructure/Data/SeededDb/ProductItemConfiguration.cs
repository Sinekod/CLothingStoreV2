using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Data.SeededDb
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            var data = new SeededDb();

            builder.HasData(new ProductItem[] {data.ProductItem1,data.ProductItem2,data.ProductItem3,data.ProductItem4});
        }
    }
}
