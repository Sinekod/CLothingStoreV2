using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Data
{
    public class ClothingStoreDbContext : IdentityDbContext
    {
        public ClothingStoreDbContext(DbContextOptions<ClothingStoreDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<DeliveryToAddress> DeliveryToAddresses { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }

    }
}
