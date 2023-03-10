using ContosoPizza.Models;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService
{
  private readonly PizzaContext _pizzaContext;
  public PizzaService(PizzaContext pizzaContext)
  {
    _pizzaContext = pizzaContext;
  }

  public IEnumerable<Pizza> GetAll()
  {
    return _pizzaContext.Pizzas.AsNoTracking().ToList();
  }

  public Pizza? GetById(int id)
  {
    return _pizzaContext
            .Pizzas
            .Include(p => p.Toppings)
            .Include(p => p.Sauce)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
  }

  public Pizza? Create(Pizza newPizza)
  {
        _pizzaContext.Pizzas.Add(newPizza);
        _pizzaContext.SaveChanges();
        return newPizza;
  }

  public void AddTopping(int pizzaId, int toppingId)
  {
    var pizzaToUpdate = _pizzaContext.Pizzas.Find(pizzaId);
    var toppingToUpdate = _pizzaContext.Toppings.Find(toppingId);

    if(pizzaToUpdate is null || toppingToUpdate is null) {
      throw new InvalidOperationException("Pizza or Toping does not exist");
    }

    if(pizzaToUpdate.Toppings is null){
      pizzaToUpdate.Toppings = new List<Topping>();
    }

        pizzaToUpdate.Toppings.Add(toppingToUpdate);
        _pizzaContext.SaveChanges();
  }

  public void UpdateSauce(int pizzaId, int sauceId)
  {
    var pizzaToUpdate = _pizzaContext.Pizzas.Find(pizzaId);
    var sauceToUpdate = _pizzaContext.Sauces.Find(sauceId);

    if(pizzaToUpdate is null || sauceToUpdate is null) {
      throw new InvalidOperationException("Pizza or Sauce does not exist");
    }

    pizzaToUpdate.Sauce = sauceToUpdate;
    _pizzaContext.SaveChanges();
  }

  public void DeleteById(int id)
  {
    var pizzaToDelete = _pizzaContext.Pizzas.Find(id);

    if(pizzaToDelete is not null) {
      _pizzaContext.Pizzas.Remove(pizzaToDelete);
      _pizzaContext.SaveChanges();
    }
  }
}