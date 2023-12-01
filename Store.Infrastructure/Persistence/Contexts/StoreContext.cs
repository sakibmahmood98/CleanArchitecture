using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.ApplicationCore.Entities;

namespace Store.Infrastructure.Persistence.Contexts;

public class StoreContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build();
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(defaultConnectionString);
        }
    }
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}