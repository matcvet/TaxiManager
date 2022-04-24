using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Services;

UserService userService = new UserService();
CarService carService = new CarService();
DriverService driverService = new DriverService();
MenuServices menuService = new MenuServices();

// Ova e samo za primer staveno tuka
userService.Add(new User("john", "john123", Roles.Administrator));
userService.Add(new User("blake", "blakeiscool", Roles.Administrator));

User user = userService.Login();

switch (user.Role)
{
    case Roles.Administrator:
        menuService.AdminMenu(user, userService);
        break;
    case Roles.Manager:
        //ManagerMenu();
        break;
    case Roles.Maintanance:
        //MaintanceMenu();
        break;
}