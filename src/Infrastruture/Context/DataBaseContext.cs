using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DomainService.Models;
using DomainService.Models.Product;
using Models.Product;

namespace Infrastruture.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<BrandModel> Brands { get; set; }
        public virtual DbSet<PCModel> Pcs { get; set; }
        public virtual DbSet<ShoppingCartModel> ShoppingCart { get; set; }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["MyConnection"];
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
