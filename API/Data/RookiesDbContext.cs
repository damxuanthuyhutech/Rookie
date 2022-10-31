
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RookiesDbContext : DbContext
    {
        public RookiesDbContext(DbContextOptions<RookiesDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderLine>? OrderLines { get; set; }
        public DbSet<Rating>? Ratings { get; set; }
    }
}
