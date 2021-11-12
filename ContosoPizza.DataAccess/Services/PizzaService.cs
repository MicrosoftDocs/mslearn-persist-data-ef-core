using ContosoPizza.DataAccess.Data;
using ContosoPizza.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.DataAccess.Services;
public class PizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pizza> GetAll()
    {
        return _context.Pizzas!
            .Include(p => p.Sauce)
            .Include(p => p.Toppings)
            .AsEnumerable();
    }

    public Pizza? GetById(int id)
    {
        return _context.Pizzas!
            .Include(p => p.Sauce)
            .Include(p => p.Toppings)
            .Where(p => p.Id == id)
            .FirstOrDefault();
    }
}