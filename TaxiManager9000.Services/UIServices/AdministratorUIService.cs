using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Helpers;

namespace TaxiManager9000.Services.UIServices
{
    public class AdministratorUIService
    {
        // Administrator privileges menu
        public static void AdminMenu(User user, UserService userService)
        {
            while (true)
            {
                Console.WriteLine("1. New user\n2. Terminate user\n3. Change password\n4. Logout\n5. Exit");
                string optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        //New user
                        User newUser = NewUser(userService);
                        userService.Add(newUser);
                        StringFormatter.Colorize("Successfully registered new user", ConsoleColor.Green);
                        break;
                    case "2":
                        //Terminate user
                        Console.Clear();
                        while (true)
                        {
                            bool userToTerminate = TerminateUser(user, userService);
                            if (userToTerminate)
                            {
                                Console.Clear();
                                StringFormatter.Colorize("User removed successfully", ConsoleColor.Green);
                                break;
                            }

                            StringFormatter.Colorize("Failed to terminate user, try again", ConsoleColor.Red);
                        }
                        break;
                    case "3":
                        //Password change
                        Console.Clear();
                        while (true)
                        {
                            bool changed = BaseUIService.HandlePasswordChange(user, userService);
                            if (changed)
                            {
                                Console.Clear();
                                StringFormatter.Colorize("Password changed successfully", ConsoleColor.Green);
                                break;
                            }

                            StringFormatter.Colorize("Password change failed", ConsoleColor.Red);
                        }
                        break;
                    case "4":
                        BaseUIService.LoginMenu(userService);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        StringFormatter.Colorize("Option doesn't exist.", ConsoleColor.Red);
                        continue;
                }
            }
        }

        // Add a new user in Db
        public static User NewUser(UserService userService)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("New user registration: ");

                Console.Write("Enter username: ");
                string usernameInput = Console.ReadLine();

                List<User> users = userService.GetAll();

                if (users.Any(x => x.Username == usernameInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Username already exists", ConsoleColor.Red);
                    continue;
                }

                if (string.IsNullOrEmpty(usernameInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Invalid username input, try again", ConsoleColor.Red);
                    continue;
                }

                Console.Write("Enter password: ");
                string passwordInput = Console.ReadLine();

                if (string.IsNullOrEmpty(passwordInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Invalid password input, try again", ConsoleColor.Red);
                    continue;
                }

                Console.WriteLine("User role:\n1. Administrator\n2. Maintanance\n3. Manager");
                string roleInput = Console.ReadLine();

                Roles role;
                switch (roleInput)
                {
                    case "1":
                        role = Roles.Administrator;
                        break;
                    case "2":
                        role = Roles.Maintanance;
                        break;
                    case "3":
                        role = Roles.Manager;
                        break;
                    default:
                        StringFormatter.Colorize("Invalid role option, try again", ConsoleColor.Red);
                        continue;
                }

                return new User(usernameInput, passwordInput, role);
            }
        }

        // Remove user from Db
        public static bool TerminateUser(User user, UserService userService)
        {
            Console.WriteLine("Terminate user: ");

            List<User> users = userService.GetAll();
            int id;

            foreach (User u in users)
            {
                Console.WriteLine(u.Print());
            }

            while (true)
            {
                Console.Write("Enter user id: ");
                string idInput = Console.ReadLine();

                if (!int.TryParse(idInput, out id))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Enter a valid id", ConsoleColor.Red);
                    continue;
                }

                if (user.Id == id)
                {
                    StringFormatter.Colorize("You can't remove yourself", ConsoleColor.Red);
                    continue;
                }

                break;
            }

            return userService.RemoveById(id);
        }
    }
}
