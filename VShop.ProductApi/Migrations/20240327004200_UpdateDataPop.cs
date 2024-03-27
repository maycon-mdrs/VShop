sing Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataPop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Smartphones");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Notebook");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Clothes");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Apple iPhone 13 (128 GB) - Luz das estrelas", "https://m.media-amazon.com/images/I/41Zbbl4P+LL._AC_SX342_SY445_.jpg", "Iphone 13", 3699.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Celular Samsung Galaxy S23 5G, 512GB, 8GB RAM, Câmera Tripla 50MP+12+10, Tela Infinita de 6.1 Preto", "https://samsungbrshop.vtexassets.com/arquivos/ids/223871-800-auto?v=638334152107230000&width=800&height=auto&aspect=true", "Samsung Galaxy S23", 5999.89m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, "Smartphone Xiaomi Redmi 12 4G 256GB - 8GB Ram (Versao Global) (Midnight Black)", "https://m.media-amazon.com/images/I/61t99wqLeaL.__AC_SX300_SY300_QL70_ML2_.jpg", "Xiaomi Redmi 12" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 4, 2, "Apple notebook MacBook Air (de 13 polegadas, Processador M1 da Apple com CPU 8‑core e GPU 7‑core, 8 GB RAM, 256 GB) - Prateado", "https://m.media-amazon.com/images/I/41-RhQeujUL.__AC_SY445_SX342_QL70_ML2_.jpg", "Macbook Air - 13", 6649.05m, 5L },
                    { 5, 3, "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão", "https://m.media-amazon.com/images/I/415M8ksnThL._AC_SX385_.jpg", "Camisa Masculina Slim Voker", 60.00m, 15L },
                    { 6, 3, "Camisa Camiseta Masculina Slim Voker Premium 100% Algodão", "https://m.media-amazon.com/images/I/41vSsY5uVDL._AC_SX385_.jpg", "Camisa branca", 60.00m, 25L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Eletrônicos");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Roupas");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Alimentos");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Um smartphone muito bom", "https://www.google.com", "Smartphone", 1999.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Uma camiseta muito bonita", "https://www.google.com", "Camiseta", 49.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "Um pacote de arroz", "https://www.google.com", "Arroz" });
        }
    }
}
