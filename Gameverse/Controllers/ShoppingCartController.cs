using Gameverse.Services;
using Gameverse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Gameverse.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ControllerBase
{
    ShoppingCartsService _service;
    
    public ShoppingCartController(ShoppingCartsService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<ShoppingCart> GetById(int id)
    {
        var shoppingCart = _service.GetById(id);

        if(shoppingCart is not null)
        {
            return shoppingCart;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] ShoppingCartDto newShoppingCart)
    {
        var shoppingCart = _service.Create(newShoppingCart);
        return CreatedAtAction(nameof(GetById), new { id = shoppingCart!.ShoppingCartId }, shoppingCart);
    }
}
