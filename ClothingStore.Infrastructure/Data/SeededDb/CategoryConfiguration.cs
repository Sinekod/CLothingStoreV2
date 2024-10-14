using ClothingStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Infrastructure.Data.SeededDb
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeededDb();

            builder.HasData(new Category[] {data.tracksuit,data.Shoes,data.Socks,data.Jacket });
        }
    }
}
