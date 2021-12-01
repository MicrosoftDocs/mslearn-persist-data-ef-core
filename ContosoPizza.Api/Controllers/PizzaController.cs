using ContosoPizza.DataAccess.Services;
using ContosoPizza.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    PizzaService _service;
    
    public PizzaController(PizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pizza>> GetAll()
    {
        return new OkObjectResult(_service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _service.GetById(id);

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
        var newPizza = _service.Create(pizza);
        return new CreatedResult(newPizza!.Id.ToString(), newPizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        var pizzaToUpdate = _service.GetById(id);

        if(pizzaToUpdate is not null)
        {
            var updatedPizza = _service.Update(id, pizza);
            return new OkObjectResult(updatedPizza);    
        }
        else
        {
            return new NotFoundResult();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _service.GetById(id);

        if(pizza is not null)
        {
            _service.DeleteById(id);
            return new OkResult();
        }
        else
        {
            return new NotFoundResult();
        }
    }
}