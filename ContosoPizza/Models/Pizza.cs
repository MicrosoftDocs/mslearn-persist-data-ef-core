namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public Sauce? Sauce { get; set; }
    
    public ICollection<Topping>? Toppings { get; set; }
}