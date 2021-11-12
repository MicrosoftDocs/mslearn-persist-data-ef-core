using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Domain.Models;

public class Sauce
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public bool IsVeganFriendly { get; set; }
}