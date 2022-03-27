using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required]
    public int Quantity { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public Category Category { get; set; }
    public ICollection<ProductShoppingCart> ProductShoppingCarts {get;set;}
}