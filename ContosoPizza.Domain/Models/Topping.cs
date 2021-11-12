using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContosoPizza.Domain.Models;

public class Topping
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Calories { get; set; }

    [JsonIgnore]
    public ICollection<Pizza>? Pizzas { get; set; }
}