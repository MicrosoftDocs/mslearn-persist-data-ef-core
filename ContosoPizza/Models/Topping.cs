using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContosoPizza.Models;

public class Topping
{
    public int Id { get; set; }
    public string? Name { get; set; }
}