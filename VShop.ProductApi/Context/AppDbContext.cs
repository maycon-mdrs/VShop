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
            .HasPrecision(12, 2);

        /* RELACIONAMENTO */
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        /* POPULAR BANCO */
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Smartphones" },
            new Category { CategoryId = 2, Name = "Notebook" },
            new Category { CategoryId = 3, Name = "Clothes" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Iphone 13",
                Price = 3699.99m,
                Description = "Apple iPhone 13 (128 GB) - Luz das estrelas",
                Stock = 10,
                ImageUrl = "https://m.media-amazon.com/images/I/41Zbbl4P+LL._AC_SX342_SY445_.jpg",
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Samsung Galaxy S23",
                Price = 5999.89m,
                Description =
                    "Celular Samsung Galaxy S23 5G, 512GB, 8GB RAM, Câmera Tripla 50MP+12+10, Tela Infinita de 6.1 Preto",
                Stock = 20,
                ImageUrl =
                    "https://samsungbrshop.vtexassets.com/arquivos/ids/223871-800-auto?v=638334152107230000&width=800&height=auto&aspect=true",
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Xiaomi Redmi 12",
                Price = 19.99m,
                Description = "Smartphone Xiaomi Redmi 12 4G 256GB - 8GB Ram (Versao Global) (Midnight Black)",
                Stock = 100,
                ImageUrl = "https://m.media-amazon.com/images/I/61t99wqLeaL.__AC_SX300_SY300_QL70_ML2_.jpg",
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Macbook Air - 13",
                Price = 6649.05m,
                Description = "Apple notebook MacBook Air (de 13 polegadas, Processador M1 da Apple com CPU 8‑core e GPU 7‑core, 8 GB RAM, 256 GB) - Prateado",
                Stock = 5,
                ImageUrl = "https://m.media-amazon.com/images/I/41-RhQeujUL.__AC_SY445_SX342_QL70_ML2_.jpg",
                CategoryId = 2
            }, 
            new Product
            {
                Id = 5,
                Name = "Camisa Masculina Slim Voker",
                Price = 60.00m,
                Description = "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão.",
                Stock = 15,
                ImageUrl = "https://m.media-amazon.com/images/I/415M8ksnThL._AC_SX385_.jpg",
                CategoryId = 3
            },
            new Product
            {
                Id = 6,
                Name = "Camisa branca",
                Price = 60.00m,
                Description = "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão.",
                Stock = 25,
                ImageUrl = "https://m.media-amazon.com/images/I/41vSsY5uVDL._AC_SX385_.jpg",
                CategoryId = 3
            }
        );
    }
}