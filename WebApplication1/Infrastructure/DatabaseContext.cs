using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        ]);
        
        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer{ Id = 1, Abbreviation = "IC", FullName =  "Intel Corporation", FoundationDate = new DateOnly(1928, 7, 18)},
            new ComponentManufacturer{Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices",  FoundationDate = new DateOnly(1969, 5, 1)},
            new ComponentManufacturer{Id = 3, Abbreviation = "NC", FullName = "Nvidia Corporation",  FoundationDate = new DateOnly(1993, 4, 5)}
        ]);
        
        modelBuilder.Entity<Component>().HasData([
            new Component { Code = "CPU001   ", Name = "Intel Core i9-14900K", Description = "High-end desktop CPU", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "RAM001   ", Name = "Kingston 32GB DDR5", Description = "DDR5 5600MHz RAM", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "GPU001   ", Name = "RTX 4090", Description = "Flagship gaming GPU", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        ]);

        modelBuilder.Entity<PC>().HasData([
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PC { Id = 3, Name = "Workstation Ultra", Weight = 18.0f, Warranty = 48, CreatedAt = new DateTime(2026, 3, 1, 10, 0, 0), Stock = 3 }
        ]);

        modelBuilder.Entity<PCComponent>().HasData([
            new PCComponent { PCId = 1, ComponentCode = "CPU001   ", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU001   ", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM001   ", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "CPU001   ", Amount = 2 }
        ]);
    }
}
