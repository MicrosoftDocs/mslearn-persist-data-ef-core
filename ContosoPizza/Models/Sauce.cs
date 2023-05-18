namespace ContosoPizza.Models;
using System.ComponentModel.DataAnnotations;

public class Sauce
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public bool IsVegan { get; set; }
}