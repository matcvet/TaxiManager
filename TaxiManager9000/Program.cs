using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Helpers;

UserService userService = new UserService();
CarService carService = new CarService();
DriverService driverService = new DriverService();

// Ova e samo za primer staveno tuka
userService.Add(new User("john", "john123", Roles.Administrator));
userService.Add(new User("blake", "blakeiscool", Roles.Administrator));

User user = userService.Login();

switch (user.Role)
{
    case Roles.Administrator:
        AdminMenu(user, userService);
        break;
    case Roles.Manager:
        //ManagerMenu();
        break;
    case Roles.Maintanance:
        //MaintanceMenu();
        break;
}

// Administrator privileges menu
static void AdminMenu(User user, UserService userService)
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
                userService.Login();
                break;
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