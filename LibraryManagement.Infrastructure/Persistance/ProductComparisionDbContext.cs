using LibraryManagement.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Persistance
{
    public class ProductComparisionDbContext : DbContext
    {
        public ProductComparisionDbContext(DbContextOptions<ProductComparisionDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
