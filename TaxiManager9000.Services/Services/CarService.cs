using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class CarService : BaseService<Car>, ICarService
    {

        public void ListVehicles()
        {
            Console.Clear();

            foreach (Car car in Db.GetAll())
            {
                Console.WriteLine($"{car.Print()} Shifts covered: {car.AsignedShifts()}");
            }
        }

        public void LicencePlateStatus()
        {
            Console.Clear();

            foreach (Car car in Db.GetAll())
            {
                if (car.ExpiaryDateLicencePlate < DateTime.Now)
                {
                    StringFormatter.Colorize(car.Print(), ConsoleColor.Red);
                    continue;
                }

                if (car.ExpiaryDateLicencePlate.Month - DateTime.Now.Month <= 3
                    && car.ExpiaryDateLicencePlate.Year == DateTime.Now.Year)
                {
                    StringFormatter.Colorize(car.Print(), ConsoleColor.Yellow);
                    continue;
                }

                StringFormatter.Colorize(car.Print(), ConsoleColor.Green);
            }
        }
    }
}
