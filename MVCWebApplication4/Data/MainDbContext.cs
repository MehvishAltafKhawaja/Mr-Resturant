using Microsoft.EntityFrameworkCore;
using MVCWebApplication4.Models;
namespace MVCWebApplication4.Data
{
    public class MainDbContext : DbContext 
    {

        public MainDbContext(DbContextOptions<MainDbContext> options) 
            : base(options) { }
        public DbSet<Intern>  Interns { get; set; }
             
    } 



}
