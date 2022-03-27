using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class Category
{
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}