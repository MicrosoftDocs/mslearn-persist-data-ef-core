using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {

            if (context.Pizzas!.Any() 
                && context.Ingredients!.Any())
            {
                return;   // DB has been seeded
            }

            var pepperoni = new Ingredient{Name="Pepperoni"};
            var sausage = new Ingredient{Name="Sausage"};
            var ham = new Ingredient{Name="Ham"};
            var pineapple = new Ingredient{Name="Pineapple"};

            var pizzas = new Pizza[]
            {
                new Pizza{Name = "Cam's Special", Price=10.99M, Ingredients = new List<Ingredient>{pepperoni, sausage, ham}},
                new Pizza{Name = "Dave's Special", Price=11.99M, Ingredients = new List<Ingredient>{pineapple, ham} }
            };

            context.Pizzas!.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}