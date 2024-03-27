using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Smartphones" },
                    { 2, "Notebook" },
                    { 3, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Apple iPhone 13 (128 GB) - Luz das estrelas", "https://m.media-amazon.com/images/I/41Zbbl4P+LL._AC_SX342_SY445_.jpg", "Iphone 13", 3699.99m, 10L },
                    { 2, 1, "Celular Samsung Galaxy S23 5G, 512GB, 8GB RAM, Câmera Tripla 50MP+12+10, Tela Infinita de 6.1 Preto", "https://samsungbrshop.vtexassets.com/arquivos/ids/223871-800-auto?v=638334152107230000&width=800&height=auto&aspect=true", "Samsung Galaxy S23", 5999.89m, 20L },
                    { 3, 1, "Smartphone Xiaomi Redmi 12 4G 256GB - 8GB Ram (Versao Global) (Midnight Black)", "https://m.media-amazon.com/images/I/61t99wqLeaL.__AC_SX300_SY300_QL70_ML2_.jpg", "Xiaomi Redmi 12", 19.99m, 100L },
                    { 4, 2, "Apple notebook MacBook Air (de 13 polegadas, Processador M1 da Apple com CPU 8‑core e GPU 7‑core, 8 GB RAM, 256 GB) - Prateado", "https://m.media-amazon.com/images/I/41-RhQeujUL.__AC_SY445_SX342_QL70_ML2_.jpg", "Macbook Air - 13", 6649.05m, 5L },
                    { 5, 3, "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão.", "https://m.media-amazon.com/images/I/415M8ksnThL._AC_SX385_.jpg", "Camisa Masculina Slim Voker", 60.00m, 15L },
                    { 6, 3, "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão.", "https://m.media-amazon.com/images/I/41vSsY5uVDL._AC_SX385_.jpg", "Camisa branca", 60.00m, 25L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
