using Microsoft.EntityFrameworkCore;
using CS.Models;

namespace CS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceProvider> ServiceProviders { get; set; }

    }
}
