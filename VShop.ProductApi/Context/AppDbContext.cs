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
        
        /* POPULAR BANCO */
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Eletrônicos" },
            new Category { CategoryId = 2, Name = "Roupas" },
            new Category { CategoryId = 3, Name = "Alimentos" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Smartphone",
                Price = 1999.99m,
                Description = "Um smartphone muito bom",
                Stock = 10,
                ImageUrl = "https://www.google.com",
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Camiseta",
                Price = 49.99m,
                Description = "Uma camiseta muito bonita",
                Stock = 20,
                ImageUrl = "https://www.google.com",
                CategoryId = 2
            },
            new Product
            {
                Id = 3,
                Name = "Arroz",
                Price = 19.99m,
                Description = "Um pacote de arroz",
                Stock = 100,
                ImageUrl = "https://www.google.com",
                CategoryId = 3
            }    
        );
    }
}