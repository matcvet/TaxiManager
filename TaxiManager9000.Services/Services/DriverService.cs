using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class DriverService : BaseService<Driver>, IDriverService
    {
        public void ListDrivers()
        {
            Console.Clear();

            foreach (Driver driver in Db.GetAll())
            {
                Console.WriteLine($"" +
                    $"{driver.Id} " +
                    $"{driver.FirstName} {driver.LastName} " +
                    $"{driver.Shift} " +
                    $"{(driver.CheckCarStatus() ? driver.AsignedCar.Model : "no car") }");
            }
        }

        public void LicencePlateStatus()
        {
            Console.Clear();

            foreach (Driver driver in Db.GetAll())
            {
                if (driver.ExpiaryDateLicence < DateTime.Now)
                {
                    StringFormatter.Colorize(driver.Print(), ConsoleColor.Red);
                    continue;
                }

                if (driver.ExpiaryDateLicence.Month - DateTime.Now.Month <= 3
                    && driver.ExpiaryDateLicence.Year == DateTime.Now.Year)
                {
                    StringFormatter.Colorize(driver.Print(), ConsoleColor.Yellow);
                    continue;
                }

                StringFormatter.Colorize(driver.Print(), ConsoleColor.Green);
            }
        }

        public void DriverManager(CarService carService)
        {
            Console.Clear();
            StringFormatter.Colorize("Driver manager", ConsoleColor.Green);
            Console.WriteLine("1. Assign driver\n2. Unassign driver");
            while (true)
            {
                string inputChoice = Console.ReadLine();

                switch(inputChoice)
                {
                    case "1":
                        AssignDriver(carService);
                        return;
                    case "2":
                        UnassignDriver();
                        return;
                    default:
                        StringFormatter.Colorize("Invalid input", ConsoleColor.Red);
                        continue;
                }
            }
        }

        public void AssignDriver(CarService carService)
        {
            Console.Clear();

            while (true)
            {
                foreach (Driver d in Db.GetAll())
                {
                    if (!d.CheckCarStatus())
                    {
                        Console.WriteLine(d.Print());
                    }
                }

                Driver driver;

                Console.WriteLine("Choose Driver by id: ");
                string driverIdInput = Console.ReadLine();

                if (!int.TryParse(driverIdInput, out int driverId))
                {
                    Console.WriteLine("Invalid id");
                    continue;
                }

                driver = Db.GetById(driverId);

                Console.WriteLine("Choose shift: ");
                Console.WriteLine("1. Morning\n2. Afternoon\n3. Evening");

                Shift shift = new Shift();
                switch (Console.ReadLine())
                {
                    case "1":
                        shift = Shift.Morning;
                        break;
                    case "2":
                        shift = Shift.Afternoon;
                        break;
                    case "3":
                        shift = Shift.Evening;
                        break;
                }

                int availableCars = 0;

                foreach(Car car in carService.GetAll())
                {
                    if (car.GetAssignedDrivers().All(x => shift != x.Shift) && car.ExpiaryDateLicencePlate > DateTime.Now)
                    {
                        Console.WriteLine($"Id: {car.Id} Model: {car.Model} Licence epxires: {car.ExpiaryDateLicencePlate}");
                        availableCars++;
                    }
                }

                if(availableCars == 0)
                {
                    Console.Clear();
                    StringFormatter.Colorize($"No available cars in the {shift} shift", ConsoleColor.Red);
                    continue;
                }

                availableCars = 0;

                Console.WriteLine("Choose car by id: ");
                string carIdInput = Console.ReadLine();

                if (!int.TryParse(carIdInput, out int carId))
                {
                    Console.WriteLine("Invalid id");
                    continue;
                }

                driver.Shift = shift;
                driver.AsignedCar = carService.GetById(carId);
                carService.GetById(carId).AsignedDrivers.Add(driver);
                StringFormatter.Colorize("Driver assigned", ConsoleColor.Green);
                break;
            }
        }

        public void UnassignDriver()
        {
            while(true)
            {
                Console.Clear();

                int driversToUnassign = 0;

                foreach (Driver d in Db.GetAll())
                {
                    if (d.CheckCarStatus())
                    {
                        Console.WriteLine(d.Print());
                        driversToUnassign++;
                    }
                }

                if(driversToUnassign == 0)
                {
                    StringFormatter.Colorize("No drivers to unassign", ConsoleColor.Red);
                    break;
                }

                Console.Write("Choose Driver by id: ");
                string driverIdInput = Console.ReadLine();

                if (!int.TryParse(driverIdInput, out int driverId))
                {
                    Console.WriteLine("Invalid id");
                    continue;
                }

                Driver driver = Db.GetById(driverId);

                driver.AsignedCar = null;
                driver.Shift = new Shift();

                StringFormatter.Colorize("Driver Unassigned", ConsoleColor.Green);
                break;
            }
        }
    }
}
