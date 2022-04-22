using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public string Licence { get; set; }
        public DateTime ExpiaryDateLicence { get; set; }
        public Car AssignedCar { get; set; }

        public Driver(string firstName, string lastName, Shift shift, string licence, DateTime expiaryDateLicence)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            Licence = licence;
            ExpiaryDateLicence = expiaryDateLicence;
        }

        public override string Print()
        {
            return $"Id: {Id}\nName: {FirstName} {LastName}\nShift: {Shift}\nLicence: {Licence} - {ExpiaryDateLicence}";
        }

        public bool CheckCarStatus()
        {
            if (AssignedCar != null)
            {
                return true;
            }

            return false;
        }
    }
}
