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
    internal class DeliveryToAddressConfiguration : IEntityTypeConfiguration<DeliveryToAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryToAddress> builder)
        {
            var data = new SeededDb();

            builder.HasData(new DeliveryToAddress[] { data.DeliveryToAddress1});
        }
    }
}
