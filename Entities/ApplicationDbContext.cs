using CakeShop.Entites;
using Microsoft.EntityFrameworkCore;

namespace CakeShopService.Entites
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) { }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
