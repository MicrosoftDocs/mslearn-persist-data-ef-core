namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }

}