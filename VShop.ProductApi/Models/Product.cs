namespace VShop.ProductApi.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    
    /* Referência à categoria a que o produto pertence */
    public Category? Category { get; set; }
    /* O ID da categoria a que o produto pertence */
    public int CategoryId { get; set; }
}