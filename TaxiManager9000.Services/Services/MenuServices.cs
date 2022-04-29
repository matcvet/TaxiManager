using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Helpers;

namespace TaxiManager9000.Services.Services
{
    public class MenuServices
    {
        // Administrator menu
        public void AdminMenu(User user, UserService userService)
        {
            while (true)
            {
                Console.WriteLine("1. New user\n2. Terminate user\n3. Change password\n4. Logout\n5. Exit");
                string optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        //New user
                        userService.AddUser();
                        Console.Clear();
                        StringFormatter.Colorize("Successfully added user", ConsoleColor.Green);
                        continue;
                    case "2":
                        //Terminate user
                        userService.RemoveUser(user);
                        Console.Clear();
                        StringFormatter.Colorize("Successfully removed user", ConsoleColor.Green);
                        continue;
                    case "3":
                        //Password change
                        userService.ChangePassword(user);
                        Console.Clear();
                        StringFormatter.Colorize("Password changed successfully", ConsoleColor.Green);
                        continue;
                    case "4":
                        //Logout
                        return;
                    case "5":
                        //Exit app
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        StringFormatter.Colorize("Option doesn't exist.", ConsoleColor.Red);
                        continue;
                }
            }
        }

        public void MaintenanceMenu(User user, UserService userService, CarService carService)
        {
            while (true)
            {
                Console.WriteLine("1. List vehicles\n2. Licence plate status\n3. Change password\n4. Logout\n5. Exit");
                string optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        //List vehicles
                        carService.ListVehicles();
                        StringFormatter.Colorize("Press enter to go back", ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case "2":
                        //Licence plate status
                        carService.LicencePlateStatus();
                        StringFormatter.Colorize("Press enter to go back", ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case "3":
                        //Password change
                        userService.ChangePassword(user);
                        Console.Clear();
                        StringFormatter.Colorize("Password changed successfully", ConsoleColor.Green);
                        continue;
                    case "4":
                        //Logout
                        return;
                    case "5":
                        //Exit app
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        StringFormatter.Colorize("Option doesn't exist.", ConsoleColor.Red);
                        continue;
                }
            }
        }

        public void ManagerMenu(User user, UserService userService, DriverService driverService, CarService carService)
        {
            while (true)
            {
                Console.WriteLine("1. List all drivers\n2. Taxi licence status\n3. Driver manager\n4. Change password\n5. Logout\n6. Exit");
                string optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        //List drivers
                        driverService.ListDrivers();
                        StringFormatter.Colorize("Press enter to go back", ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case "2":
                        //Taxi licence status
                        driverService.LicencePlateStatus();
                        StringFormatter.Colorize("Press enter to go back", ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case "3":
                        //Driver manager
                        driverService.DriverManager(carService);
                        StringFormatter.Colorize("Press enter to go back", ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case "4":
                        //Password change
                        userService.ChangePassword(user);
                        Console.Clear();
                        StringFormatter.Colorize("Password changed successfully", ConsoleColor.Green);
                        continue;
                    case "5":
                        //Logout
                        return;
                    case "6":
                        //Exit app
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        StringFormatter.Colorize("Option doesn't exist.", ConsoleColor.Red);
                        continue;
                }
            }
        }
    }
}
