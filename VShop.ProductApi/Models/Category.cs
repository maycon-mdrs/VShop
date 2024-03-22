namespace VShop.ProductApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    
    /* Uma coleção de produtos que pertencem a esta categoria */
    
    /*
     * ICollection é uma interface genérica no .NET que representa uma coleção de elementos.
     * Ela está definida no namespace System.Collections.Generic.
     * 
     * Add(T item): Adiciona um item à coleção.
     * Clear(): Remove todos os itens da coleção.
     * Contains(T item): Verifica se a coleção contém um determinado item.
     * Remove(T item): Remove a primeira ocorrência de um item específico da coleção.
     * Count: Propriedade que retorna o número de elementos na coleção.
     */
    public ICollection<Product>? Products { get; set; } 
}