using Gameverse.Models;
using Gameverse.Data;
using Microsoft.EntityFrameworkCore;

namespace Gameverse.Services;

public class UserService
{
    private readonly GameverseContext _context;

    public UserService(GameverseContext context)
    {
        _context = context;
    }

    public User? GetById(int id)
    {
        var user = _context.Users
            .Include(p => p.Id)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
        return user;
    }

    public User Create(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();

        return newUser;
    }

   public void SetRole(int UserId, int RoleId)
    {
        var userToUpdate = _context.Users.Find(UserId);
        var roleToAdd = _context.Roles.Find(RoleId);

        if (userToUpdate is null || roleToAdd is null)
        {
            throw new NullReferenceException("User or role does not exist");
        }

        if(userToUpdate.Role is null)
        {
            userToUpdate.Role = new Role();
        }

        userToUpdate.Role = roleToAdd;

        _context.Users.Update(userToUpdate);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var userToDelete = _context.Users.Find(id);
        if (userToDelete is not null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }        
    }

    public IEnumerable<Role> GetRoles(){
        var roles = _context.Roles.ToList();
        if (roles is null)
        {
            throw new NullReferenceException("No roles");
        }

        return roles;
    }
}