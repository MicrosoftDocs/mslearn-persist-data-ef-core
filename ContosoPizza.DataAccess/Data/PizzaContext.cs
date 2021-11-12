using Microsoft.EntityFrameworkCore;
using ContosoPizza.Domain.Models;

namespace ContosoPizza.DataAccess.Data;

public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    public DbSet<Pizza>? Pizzas { get; set; }
    public DbSet<Topping>? Toppings { get; set; }
    public DbSet<Sauce>? Sauces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().ToTable("Pizza");
        modelBuilder.Entity<Sauce>().ToTable("Sauce");
        modelBuilder.Entity<Topping>().ToTable("Topping");
    }
}

