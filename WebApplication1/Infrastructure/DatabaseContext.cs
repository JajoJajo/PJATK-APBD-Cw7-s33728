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
        
    }
}
