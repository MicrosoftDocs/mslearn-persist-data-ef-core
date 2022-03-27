using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class ProductShoppingCart
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
}