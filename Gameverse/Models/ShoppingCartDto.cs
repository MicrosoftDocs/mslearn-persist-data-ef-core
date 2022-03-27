using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class ShoppingCartDto
{
    public int ShoppingCartId { get; set; }

    [Required]
    public int? Price { get; set; }
    [Required]
    public int UserId { get; set; }
}