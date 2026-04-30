using Microsoft.EntityFrameworkCore;
using MvcLab1.Models;

namespace MvcLab1.Data;

public class AppDbContext : DbContext  // ← ДОЛЖНО БЫТЬ наследование от DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

  
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            entity.HasIndex(p => p.Category)
                .HasDatabaseName("IX_Products_Category");
        });

    }
}
