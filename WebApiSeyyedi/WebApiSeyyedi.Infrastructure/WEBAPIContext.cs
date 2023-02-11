using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebApiSeyyedi.Data;
using WebApiSeyyedi.Data.Models;

namespace WebApiSeyyedi.Infrastructure
{
    public class WEBAPIContext : DbContext
    {
        public WEBAPIContext() { }
        public WEBAPIContext(DbContextOptions contextOptions) : base(contextOptions) { }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> userRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? connectionString = ConfigurationHelper.Config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}