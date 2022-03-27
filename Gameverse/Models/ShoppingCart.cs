using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class ShoppingCart
{
    public int ShoppingCartId { get; set; }

    [Required]
    public int? Price { get; set; }
    [Required]
    public User User { get; set; }
    public ICollection<ProductShoppingCart>? ProductShoppingCarts { get; set; }
}