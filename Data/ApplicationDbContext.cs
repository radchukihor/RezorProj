using Microsoft.EntityFrameworkCore;
using RazorProjectWeb.Model;

namespace RazorProjectWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Category> Category { get; set; }
    }
}
