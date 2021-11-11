using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    PizzaContext _context;
    
    public PizzaController(PizzaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pizza>> GetAll()
    {
        return new OkObjectResult(_context.Pizzas!.Include(p => p.Ingredients).AsEnumerable());
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _context.Pizzas!.Include(p => p.Ingredients).Where(p => p.Id == id).FirstOrDefault();
        if(pizza is not null)
        {
            return new OkObjectResult(pizza);
        }
        else
        {
            return new NotFoundResult();
        }
    }


    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        return new BadRequestResult();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        return new NotFoundResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return new NotFoundResult();
    }

}