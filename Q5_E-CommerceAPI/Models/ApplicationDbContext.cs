using Microsoft.EntityFrameworkCore;

namespace Q5_E_CommerceAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
