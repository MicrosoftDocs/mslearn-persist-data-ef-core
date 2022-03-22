using Gameverse.Models;

namespace Gameverse.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context)
        {

            if (context.Users.Any()
                && context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            var adminRole = new Role { Name = "Admin"};
            var customerRole = new Role { Name = "Customer" };

            var users = new User[]
            {
                new User
                    { 
                        Name = "Paul Nate", 
                        Role = adminRole
                    },
                new User
                    { 
                        Name = "George B", 
                        Role = customerRole
                    }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}