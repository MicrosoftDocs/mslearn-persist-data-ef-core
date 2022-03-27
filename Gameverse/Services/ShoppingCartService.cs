using Gameverse.Models;
using Gameverse.Data;
using Microsoft.EntityFrameworkCore;

namespace Gameverse.Services;

public class ShoppingCartsService
{
    private readonly GameverseContext _context;

    public ShoppingCartsService(GameverseContext context)
    {
        _context = context;
    }

    public ShoppingCart? GetById(int id)
    {
        var shoppingCart = _context.ShoppingCarts
            .Include(x => x.User)
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .SingleOrDefault(p => p.ShoppingCartId == id);
        return shoppingCart;
    }
    public ShoppingCart Create(ShoppingCartDto shoppingCart)
    {
        var newShoppingCart = new ShoppingCart(){
            Price = 0,
            User = _context.Users.Find(shoppingCart.UserId)
        };
        _context.ShoppingCarts.Add(newShoppingCart);
        _context.SaveChanges();

        return newShoppingCart;
    }
}