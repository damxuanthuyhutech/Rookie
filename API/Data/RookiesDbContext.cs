using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RookiesDbContext : DbContext
    {
        public RookiesDbContext(DbContextOptions<RookiesDbContext> opt) : base(opt)
        {

        }

        #region Dbset
        public DbSet<Size> sizes { get; set; } = null!;
        public DbSet<Order> orders { get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;
        public DbSet<OrderItem> orderItems { get; set; } = null!;
        public DbSet<Rating> ratings { get; set; } = null!;
        public DbSet<User> users { get; set; } = null!;
        public DbSet<CartItem> cartItems { get; set; } = null!;
        public DbSet<Category> categories { get; set; } = null!;
        public DbSet<Image> images { get; set; } = null!;
        public DbSet<Roles> roles { get; set; } = null!;
        //public DbSet<ProductCategory> productCategories { get; set; } = null!;
        //public DbSet<UserRoles>? userRoles { get; set; }
        ////public DbSet<ProductSize> productSizes { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
                
               
            }
        }
    }
}
