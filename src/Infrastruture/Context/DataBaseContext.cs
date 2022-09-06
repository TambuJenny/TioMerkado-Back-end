
using System.Configuration;
using DomainService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastruture.Context
{
    public  class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<UsuarioModel> Usuarios {get; set; }

    }
   
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
         
        public DataBaseContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration["MyConnection"];
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));

            return new DataBaseContext(optionsBuilder.Options);
        }
    }

}