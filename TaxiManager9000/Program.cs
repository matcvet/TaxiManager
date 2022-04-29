using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Services;

UserService userService = new UserService();
CarService carService = new CarService();
DriverService driverService = new DriverService();
MenuServices menuService = new MenuServices();

// Ova e samo za primer staveno tuka
userService.Add(new User("john", "john123", Roles.Administrator));
userService.Add(new User("drake", "drake123", Roles.Maintenance));
userService.Add(new User("toni", "bonboni", Roles.Manager));

driverService.Add(new Driver("Chris", "Rock", "VGT33AALLK", new DateTime(2025, 10, 6)));
driverService.Add(new Driver("Bon", "Ton", "AYYTHM3FBN", new DateTime(2023, 2, 1)));
driverService.Add(new Driver("Ham", "Burger", "ASDBVN323F", new DateTime(2019, 11, 11)));
driverService.Add(new Driver("Tuna", "Fish","SDFBFD4FSDF", new DateTime(2022, 5, 30)));
driverService.Add(new Driver("The", "Rock", "4FSDFV324F", new DateTime(2022, 7, 27)));

carService.Add(new Car("Porsche", "SK223VP", new DateTime(2023, 6, 20)));
carService.Add(new Car("Ferrari", "SK777GG", new DateTime(2022, 10, 10)));
carService.Add(new Car("Bentley", "SK007JB", new DateTime(2022, 1, 15)));
carService.Add(new Car("Mercedes", "SK123BB", new DateTime(2022, 6, 23)));

while(true)
{
    User user = userService.Login();

    switch (user.Role)
    {
        case Roles.Administrator:
            menuService.AdminMenu(user, userService);
            break;
        case Roles.Manager:
            menuService.ManagerMenu(user, userService, driverService, carService);
            break;
        case Roles.Maintenance:
            menuService.MaintenanceMenu(user, userService, carService);
            break;
    }
}