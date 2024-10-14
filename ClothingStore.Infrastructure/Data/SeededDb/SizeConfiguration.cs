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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            var data = new SeededDb();

            builder.HasData(new Size[] {data.S,data.L,data.M,data.SockSize,data.ShoeSize });

        }
    }
}
