using System.ComponentModel.DataAnnotations;

namespace Gameverse.Models;

public class Role
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<User>? users { get; set; }
}