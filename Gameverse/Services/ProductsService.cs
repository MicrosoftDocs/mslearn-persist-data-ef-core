using Gameverse.Models;
using Gameverse.Data;
using Microsoft.EntityFrameworkCore;

namespace Gameverse.Services;

public class ProductsService
{
    private readonly GameverseContext _context;

    public ProductsService(GameverseContext context)
    {
        _context = context;
    }

    public Product? GetById(int id)
    {
        var product = _context.Products
            .AsNoTracking()
            .SingleOrDefault(p => p.ProductId == id);
        return product;
    }
    public Product Create(Product newProduct)
    {
        _context.Products.Add(newProduct);
        _context.SaveChanges();

        return newProduct;
    }
    public IEnumerable<Product> GetProducts()
    {
        var products = _context.Products.ToList();
        return products;
    }
    public IEnumerable<Product> GetByPriceMax(double price)
    {
        var products = _context.Products
        .Where(x => x.Price <= price)
        .ToList();
        return products;
    }
    public IEnumerable<Product> GetByCategory(int categoryId)
    {
        var products = _context.Products
        .Where(c => c.Category.CategoryId == categoryId).ToList();
        return products;
    }
    public IEnumerable<Product> GetByShoppingCart(int ShoppingCartId)
    {
        var products = _context.Products.
        Include(x => x.ProductShoppingCarts)
        .ThenInclude(x => x.ShoppingCartId);
        return products;
    }
    public void AddToShoppingCart(int ProductId, int ShoppingCartId)
    {
        var productToUpdate = _context.Products.Find(ProductId);
        var destinationShoppingCart = _context.ShoppingCarts.Find(ShoppingCartId);

        if (productToUpdate is null || destinationShoppingCart is null)
        {
            throw new NullReferenceException("Product or ShoppingCart does not exist");
        }

        productToUpdate.ProductShoppingCarts.Add(new ProductShoppingCart{
            Product = productToUpdate,
            ShoppingCart = destinationShoppingCart,
        });

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var productToDelete = _context.Products.Find(id);
        if (productToDelete is not null)
        {
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }        
    }
}