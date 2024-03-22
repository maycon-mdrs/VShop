using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    /* Coleção de entidades no contexto do banco de dados */
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* CATEGORIA */
        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId);
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    
        /* PRODUTO */
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(255);

        modelBuilder.Entity<Product>()
            .Property(p => p.ImageUrl)
            .HasMaxLength(255);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(12,2);
        
        /* RELACIONAMENTO */
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}