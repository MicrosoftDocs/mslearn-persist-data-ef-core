using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return new List<Pizza>();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Results.NotFound();
        return new NotFoundResult();
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