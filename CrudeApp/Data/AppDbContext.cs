using CrudeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudeApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

                
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }
}
