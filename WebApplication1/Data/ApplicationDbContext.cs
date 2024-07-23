using Microsoft.EntityFrameworkCore;
using WebApplication1.Model.Entities;

namespace WebApplication1.Data
{
    public class ApplicationDbContext:DbContext
    {
       
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee>employees { get; set; }   
    }
}
