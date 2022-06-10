using Microsoft.EntityFrameworkCore;
using staff_control_panel.Models;

namespace staff_control_panel.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Employee> Employees { get; set; }
       public DbSet<Post> Posts { get; set; }   
    }
}
