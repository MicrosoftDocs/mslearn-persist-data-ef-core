using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext (DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
        }
    }
}