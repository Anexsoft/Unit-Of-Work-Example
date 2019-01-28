using Model;
using System;
using UnitOfWork;
using UnitOfWorkPersistence;
using UnitOfWorkServices;

namespace UnitOfWorkConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application");

            // Create instance of database
            using (var context = new ApplicationDbContext())
            {
                // Prepare unit Of Work
                IUnitOfWork uow = new UnitOfWorkContainer(context);

                // Prepare services
                IUserService userService = new UserService(uow);

                // First Test
                //CreateUserExample(userService);

                // Second Case
                PagedUserExample(userService);
            }

            Console.WriteLine("Ending application");
            Console.Read();
        }

        static void CreateUserExample(IUserService userService)
        {
            Console.WriteLine("Test #1 - Creating new user");

            var rnd = new Random();
            var value = rnd.Next(1, 999999);

            userService.Create(new UserExample
            {
                LastName = $"LastName {value}",
                Name = $"User {value}",
                WebSite = "http://anexsoft.com"
            });

            var i = 1;
            foreach (var user in userService.GetAll())
            {
                Console.WriteLine($"\t{i}. {user.Name} - {user.WebSite}");
                i++;
            }
        }

        static void PagedUserExample(IUserService userService)
        {
            Console.WriteLine("Test #2 - Retrieving top first users from page 1");

            var data = userService.Paged(1, 10);

            var i = 1;
            foreach (var user in data.Items)
            {
                Console.WriteLine($"\t{i}. {user.Name} - {user.WebSite}");
                i++;
            }

            Console.WriteLine($"Current page: {data.Page}/{data.Pages} pages");
            Console.WriteLine($"Total records: {data.Pages}");
        }
    }
}
