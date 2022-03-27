using Gameverse.Models;

namespace Gameverse.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameverseContext context)
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
                    Email = "paulnate80@yahoo.com",
                    Role = adminRole
                },
                new User
                { 
                    Name = "George B", 
                    Email = "georgeb35@gmail.com",
                    Role = customerRole
                }
            };

            context.Users.AddRange(users);

            var gameCategory = new Category { Name="Game"};
            var mediaCategory = new Category { Name="Media"};

            var products = new Product[]{
                new Product
                {
                    Name = "Elden Ring",
                    Quantity = 100,
                    Description = "Elden Ring is an action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment. The game was directed by Hidetaka Miyazaki and made in collaboration with fantasy novelist George R. R. Martin, who provided material for the game's setting. It was released for Microsoft Windows, PlayStation 4, PlayStation 5, Xbox One, and Xbox Series X/S on February 25, 2022.",
                    Price = 59.99,
                    Category = gameCategory
                },
                new Product
                {
                    Name = "Pirates and Knights",
                    Quantity = 100,
                    Description = "Pirates and Knights is an adventure role-playing game developed by NP Studios.",
                    Price = 20.00,
                    Category = gameCategory
                },
                new Product
                {
                    Name = "Sekiro: Shadows die twice",
                    Quantity = 100,
                    Description = "Sekiro: Shadows Die Twice[a] is a 2019 action-adventure game developed by FromSoftware and published by Activision. The game follows a shinobi known as Wolf as he attempts to take revenge on a samurai clan who attacked him and kidnapped his lord. It was released for Microsoft Windows, PlayStation 4, and Xbox One in March 2019 and for Stadia in October 2020. "
                    +"Gameplay is focused on stealth, exploration, and combat, with a particular emphasis on boss battles. The game takes place in a fictionalized Japan during the Sengoku period and makes strong references to Buddhist mythology and philosophy. While making the game, lead director Hidetaka Miyazaki wanted to create a new intellectual property (IP) that marked a departure from the Souls series of games also made by FromSoftware. The developers looked to games such as The Mysterious Murasame Castle and the Tenchu series for inspiration."
                    +"Sekiro was praised by critics, who complimented its gameplay and setting, and compared it to the Souls games, although opinions on its difficulty were mixed. It was nominated for various awards and won several, including The Game Award for Game of the Year. The game sold over five million copies by July 2020.",
                    Price = 30.00,
                    Category = gameCategory
                },
                new Product
                {
                    Name = "Stormveil Castle",
                    Quantity = 10,
                    Description = "A picture of a very cool castle",
                    Price = 10.00,
                    Category = mediaCategory
                }
            };

            context.Products.AddRange(products);
            
            context.SaveChanges();
        }
    }
}