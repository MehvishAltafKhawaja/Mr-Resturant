using Microsoft.EntityFrameworkCore;
using MVCWebApplication4.Models;

namespace MVCWebApplication4.Data
{
    public class ModernFoodDbContext : DbContext
    {
        public ModernFoodDbContext(DbContextOptions<ModernFoodDbContext> options)
           : base(options) { }
        public DbSet<Modern> Moderns { get; set; }
    }
}
