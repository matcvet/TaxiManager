using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Helpers;

namespace TaxiManager9000.Services.UIServices
{
    public class BaseUIService
    {
        // Start the application
        public static void StartApp()
        {
            UserService userService = new UserService();
            CarService carService = new CarService();
            DriverService driverService = new DriverService();

            userService.Add(new User("john", "john123", Roles.Administrator));
            userService.Add(new User("blake", "blakeiscool", Roles.Administrator));

            User user = LoginMenu(userService);

            switch (user.Role)
            {
                case Roles.Administrator:
                    AdministratorUIService.AdminMenu(user, userService);
                    break;
                case Roles.Manager:
                    //ManagerMenu();
                    break;
                case Roles.Maintanance:
                    //MaintanceMenu();
                    break;
            }
        }

        // Prompt for user login
        public static User LoginMenu(UserService userService)
        {
            Console.Clear();

            User user;

            while (true)
            {
                Console.WriteLine("Taxi Manager 9000\nLogin: ");
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine();
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                user = userService.Login(usernameInput, passwordInput);

                if (user == null)
                {
                    Console.Clear();
                    StringFormatter.Colorize("Login failed, please try again", ConsoleColor.Red);
                    continue;
                }

                Console.Clear();
                StringFormatter.Colorize($"Successfully logged in, welcome {user.Username}!", ConsoleColor.Green);
                return user;
            }
        }

        // Change given user password
        public static bool HandlePasswordChange(User user, UserService userService)
        {
            Console.WriteLine("Change password: ");
            while (true)
            {
                Console.Write("Enter old password: ");
                string oldPassword = Console.ReadLine();

                Console.Write("Enter new password: ");
                string newPassword = Console.ReadLine();

                if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Neither of the inputs can be empty, try again", ConsoleColor.Red);
                    continue;
                }

                return userService.ChangePassword(user.Id, oldPassword, newPassword);
            }
        }
    }
}
