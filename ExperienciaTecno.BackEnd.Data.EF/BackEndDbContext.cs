using ExperienciaTecno.BackEnd.Core.Category.Models;
using ExperienciaTecno.BackEnd.Core.Specifications.Models;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using ExperienciaTecno.BackEnd.Data.EF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ExperienciaTecno.BackEnd.Data.EF;

public class BackEndDbContext(DbContextOptions<BackEndDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Especification> Especification { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CategoryMapping().Configure(modelBuilder.Entity<Category>());
        new ManufacturerMapping().Configure(modelBuilder.Entity<Manufacturer>());
        new ProductMapping().Configure(modelBuilder.Entity<Product>());
    }
}
