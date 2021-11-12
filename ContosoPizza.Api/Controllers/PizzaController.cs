using ContosoPizza.DataAccess.Services;
using ContosoPizza.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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