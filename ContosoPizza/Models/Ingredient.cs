using System.Text.Json.Serialization;

namespace ContosoPizza.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public ICollection<Pizza>? Pizzas { get; set; }
}