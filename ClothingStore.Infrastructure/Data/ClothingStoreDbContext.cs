using ClothingStore.Infrastructure.Data.Models;
using ClothingStore.Infrastructure.Data.SeededDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ClothingStore.Infrastructure.Data
{
    public class ClothingStoreDbContext : IdentityDbContext
    {
        public ClothingStoreDbContext(DbContextOptions<ClothingStoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
            .HasOne(c => c.ProductItem)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.ProductItemId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ColourConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());

            builder.ApplyConfiguration(new GenderConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new ProductItemConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }


        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }

        public virtual DbSet<Size> Sizes { get; set; }

        public virtual DbSet<OrderItems> OrderItems { get; set; }



    }
}
