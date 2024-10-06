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
    }
}
